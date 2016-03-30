$(function() {
// BEGIN OF DIALOG 
    // dialog to show some data of the tables
    dataDialog = $("#dataDialog").dialog({
        autoOpen: false,
        modal: true,
        maxHeight: 300,
        maxWidth: 500,
        width:'auto',
        height:'auto',
        resizable: false
    });

    // dialog to confirm if the TIM 
    confirmDialog = $("#confirmSave").dialog({
        autoOpen: false,
        resizable: false,
        height: 120,
        modal: true,
        title: "Confirmation dialog",
        buttons: {
            Save: function() {
                saveTIM();
                $(this).dialog("close");
            },
            Cancel: function() {
                $(this).dialog("close");
            }
        }
    });
// END OF DIALOG 

// BEGIN OF DIAGRAM 
    var graphScale = 1;
    var fileName = "json/saved.json";
    var graph = new joint.dia.Graph;
    var uml = joint.shapes.uml;
    var classes = Array();
    var relations = Array();
    var contents = Array();

    // create the jointJS Paper element (that will be the content of the TIM)
    var paper = new joint.dia.Paper({
        el: $('#paper'),
        width: $('#paper').width(),
        height: $('#paper').height(),
        gridSize: 1,
        model: graph
    });

    // read the Json file
    var file = $.getJSON( fileName, function() {
        console.log( "success" );
    })
    .done(function(data) {
        // loop trought the classes of the json file
        $.each( data["TIMlayout"], function( i, item ) {
            // create each class with the information of the json file
            classes[i] = new uml.Class({
                index: i,
                id: item.id, 
                position: { x: item.position.x, y: item.position.y },
                size: { width: item.size.width, height: item.size.height },
                name: item.name,
                attributes: item.attributes,
                methods: item.functions
            });
            contents[i] = item.content;
        });

        _.each(classes, function(c) { graph.addCell(c); });

        // loop trought the links of the json file
        $.each( data["links"], function( i, item ) {
            // create each link with the information of the json file
            relations[i] = new uml.Line({ source: { id: item.source }, target: { id: item.target }, vertices: item.vertices});
        });

        _.each(relations, function(r) { graph.addCell(r); });

    })
    .fail( function(d, textStatus, error) {
        console.error("getJSON failed, status: " + textStatus + ", error: "+error)
    });
// END DIAGRAM

// BEGIN SAVE TIM
    function saveTIM() {
        var TIMlayout = Array();
        var links = Array();

        for (var i = 0; classes[i] != undefined; i++){
            TIMlayout[i] = {
                id: classes[i].get("id"),
                position: classes[i].get("position"),
                size: classes[i].get("size"),
                name: classes[i].get("name"),
                attributes: classes[i].get("attributes"),
                functions: classes[i].get("methods"),
                content: contents[i]
            };
        }

        for (i = 0; relations[i] != undefined; i++){
            links[i] = {
                source: relations[i].get("source").id,
                target: relations[i].get("target").id,
                vertices: relations[i].get("vertices")
            };
        }

        var jsonString = {
            TIMlayout: TIMlayout,
            links: links
        };

        $.post("json.php", {json : JSON.stringify(jsonString)});
    }
// END SAVE TIM

// BEGIN ONCLICK EVENTS
    $("#zoomIN").click(function() {
        graphScale += 0.1;
        paper.scale(graphScale, graphScale);
    });

    $("#zoomOUT").click(function() {
        graphScale -= 0.1;
        paper.scale(graphScale, graphScale);
    });

    $("#savebtn").click(function() {
        $("#confirmSave").append('Are you sure you want to save this TIM?');
        confirmDialog.dialog("open");
    });

    $("#exportbtn").click(function() {
        html2canvas($("#paper"), {
            onrendered: function(canvas) {
                theCanvas = canvas;
                document.body.appendChild(canvas);

                // Convert and download as image 
                Canvas2Image.saveAsPNG(canvas); 
                // Clean up 
                document.body.removeChild(canvas);
            }
        });
    });
// END ONCLICK EVENTS

// BEGIN DOUBLECLICK TO SHOW DATA
    paper.on('cell:pointerdblclick', 
        function(cellView, evt, x, y) { 
            $("#dataDialog").html('');
            var entity = graph.getCell(cellView.model.id);
            var data = contents[entity.get("index")];

            if (Object.keys(data).length == 0)
                $("#dataDialog").append("There is no data in this table.");
            else {
                var attrs = entity.get('attributes');
                var heading = '<div class="heading">';
                var rows = "";

                for (var i = 0; i < Object.keys(attrs).length; i++)
                    heading += '<div class="cell">' + attrs[i] + '</div>';
                
                heading += "</div>";

                for (var i = 0; i < Object.keys(data).length; i++){
                    if (i % 2)
                        rows += '<div class="oddRow">';
                    else
                        rows += '<div class="evenRow">';

                    for (var j = 0; j < Object.keys(attrs).length; j++)
                        rows += '<div class="cell">' + data[i][attrs[j]] + '</div>';
                    rows += '</div>';
                }

                $("#dataDialog").append('<div class="table">' + heading + rows + '</div>');
            }

            dataDialog.dialog("option", "title", entity.getClassName() + " data");
            dataDialog.dialog("open");
        }
    );
// END DOUBLECLICK TO SHOW DATA

// BEGIN RESIZE PAPER RELATIVE TO WINDOW
    $(window).on("resize", function() {
        paper.setDimensions($("#paper").css("width"), $("#paper").css("height"));
    });
// END RESIZE PAPER RELATIVE TO WINDOW

// BEGIN SPEECH RECOGNITION
    //Test browser support
    if ('webkitSpeechRecognition' in window) {
        $("#mic").show();
        var recognizer = new webkitSpeechRecognition();
        var transcription = document.getElementById('texteareaQuery');

        // Recogniser doesn't stop listening even if the user pauses
        recognizer.continuous = true;
        // Set if we need interim results
        recognizer.interimResults = false;

        // Start recognising
        recognizer.onresult = function(event) {
            for (var i = event.resultIndex; i < event.results.length; i++) {
                if (event.results[i].isFinal) {
                    transcription.textContent += event.results[i][0].transcript;
                } else {
                    transcription.textContent += event.results[i][0].transcript;
                }
            }
        };

        var isOn = false;

        $("#mic").click(function() {
            if (isOn){
                recognizer.stop();
                $("#mic").attr("src","images/mic_off.png");
                isOn = false;
            } else {
                recognizer.start();
                $("#mic").attr("src","images/mic_on.png");
                isOn = true;
            }
        });
    }
// END SPEECH RECOGNITION
});