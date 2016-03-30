$(function() {    
// BEGIN OF DIALOG 
    dialogNotCorret = $("#dialogNotCorret").dialog({
        autoOpen: false,
        modal: true,
        width:'auto',
        height:'auto',
        resizable: false,
        title: "What is wrong?",
        buttons: {
            Submit: function() {
                $(this).dialog("close");
            }
        }
    });
// END OF DIALOG 

// BEGIN OF DIAGRAM 
    var graphScale = 1;
    var fileName = "json/VTML.json";
    var graph = new joint.dia.Graph;
    var uml = joint.shapes.uml;
    var classes = Array();
    var relations = Array();
    var contents = Array();
    var classesIcons = Array();

    // create the jointJS Paper element (that will be the content of the TIM)
    var paper = new joint.dia.Paper({
        el: $('#paper'),
        width: $('#vtml').width(),
        height: ($('#vtml').height() - 20),
        gridSize: 1,
        model: graph
    });

    //paper.$el.css('pointer-events', 'none');

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

            classesIcons[i] = {
                id: item.id,
                qtdAttr: item.attributes.length,
                qtdFunc: item.functions.length
            };
        });

        _.each(classes, function(c) { graph.addCell(c); });

        // loop trought the links of the json file
        $.each( data["links"], function( i, item ) {
            // create each link with the information of the json file
            relations[i] = new uml.Line({ source: { id: item.source }, target: { id: item.target }, vertices: item.vertices});
        });

        _.each(relations, function(r) { graph.addCell(r); });

        $.each( data["SQL"], function( i, item ) {
            $("#nlq").append("NLQ: " + item.NQL);

            // Format the SQL query
            $("#sql").append("<p>" + formatSQL(item.SQL) + "</p>");

            if (item.content.lenght == 0)
                $("#table").append("There is no result for this search.");
            else {
                var attrs = item.attributes;
                var cont = item.content;
                var heading = '<div class="heading">';
                var rows = "";

                for (var i = 0; i < attrs.length; i++)
                    heading += '<div class="cell">' + attrs[i] + '</div>';
                
                heading += "</div>";

                for (var i = 0; i < cont.length; i++){
                    if (i % 2)
                        rows += '<div class="oddRow">';
                    else
                        rows += '<div class="evenRow">';

                    for (var j = 0; j < attrs.length; j++)
                        rows += '<div class="cell">' + cont[i][attrs[j]] + '</div>';
                    rows += '</div>';
                }

                $("#table").append(heading + rows);
            }
        });

        //add icons
        $("g.element.uml.Class").each(function( index ) {
            var classID = $(this).attr("model-id");
            for (var x = 0; x < classesIcons.length; x++){
                var polygonsAttr = "";
                var polygonsFunc = "";

                attrTY = $(this).find(".uml-class-attrs-text").attr("transform").replace("translate(", "").replace(")","").split(",")[1] - 1;
                funcTY = $(this).find(".uml-class-methods-text").attr("transform").replace("translate(", "").replace(")","").split(",")[1] - 1;

                if (classesIcons[x].id == classID){
                    for (var j = 0; j < classesIcons[x].qtdAttr; j++){
                        polygonsAttr += '<polygon points="0 0, 0 10, 10 10, 10 6, 8 6, 8 9, 7 9, 7 3, 4 3, 4 9, 3 9, 3 0, 0 0" transform="translate(3, ' + attrTY + ')" fill="black"></polygon>';
                        attrTY += 12;
                    }

                    for (j = 0; j < classesIcons[x].qtdFunc; j++){
                        polygonsFunc += '<polygon points="0 0, 10 0, 6 4, 6 10, 4 10, 4 4, 0 0" transform="translate(3, ' + funcTY + ')" fill="black"></polygon>';
                        funcTY += 12;
                    }
                
                    var replaced = $(this).html().replace('attricons', polygonsAttr);
                    $(this).html(replaced);
                    replaced = $(this).html().replace('funcicons', polygonsFunc);
                    $(this).html(replaced);
                }
            }    
        });

    })
    .fail( function(d, textStatus, error) {
        console.error("getJSON failed, status: " + textStatus + ", error: "+error)
    });
// END OF DIAGRAM 




// BEGIN FORMAT SQL 
    function formatSQL(sqlString) {
        var sql = "";
        var sqlKeywords = ["AND", "AS", "ASC", "BETWEEN", "BY", "CASE", "CURRENT_DATE", "CURRENT_TIME", "DELETE", "DESC", "DISTINCT", "EACH", "ELSE", "ELSEIF", "FALSE", "FOR", "FROM", "GROUP", "HAVING", "IF", "IN", "INSERT", "INTERVAL", "INTO", "IS", "JOIN", "KEY", "KEYS", "LEFT", "LIKE", "LIMIT", "MATCH", "NOT", "NULL", "ON", "OPTION", "OR", "ORDER", "OUT", "OUTER", "REPLACE", "RIGHT", "SELECT", "SET", "TABLE", "THEN", "TO", "TRUE", "UNION", "UPDATE", "VALUES", "WHEN", "WHERE"];
        var sqlKeywordsToBreakLine = ["FROM", "WHERE", "GROUP", "ORDER", "JOIN", "INNER", "AND"];
        var query = sqlString.split(" ");

        for (var i = 0; i < query.length; i++) {
            var word = query[i];

            if ($.inArray(word.toUpperCase(), sqlKeywords) != -1) {
                var indentation = "";

                if ($.inArray(word.toUpperCase(), sqlKeywordsToBreakLine) != -1) {
                    sql += "</br>";
                    indentation = Array(6 - word.length).join("&nbsp;&nbsp;");
                }

                sql += "<b style='color: #166d9b;'>" + indentation + word.toUpperCase() + "</b>";
            } else {
                sql += word;
            }

            sql += " ";
        }
        return sql;
    }
// END FORMAT SQL 

// BEGIN RESIZE PAPER RELATIVE TO WINDOW
    $("#zoomIN").click(function() {
        graphScale += 0.1;
        paper.scale(graphScale, graphScale);
    });

    $("#zoomOUT").click(function() {
        graphScale -= 0.1;
        paper.scale(graphScale, graphScale);
    });

    $("#btnBack").click(function() {
        window.location.href = "tim.htm";
    });

    $("#btnNotCorret").click(function() {
        dialogNotCorret.dialog("open");
    });
// END RESIZE PAPER RELATIVE TO WINDOW

// BEGIN RESIZE PAPER RELATIVE TO WINDOW
    $(window).on("resize", function() {
        paper.setDimensions($('#vtml').width(), ($('#vtml').height() - 20));
    });
// END RESIZE PAPER RELATIVE TO WINDOW
});