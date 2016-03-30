<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" />

<xsl:template match="sapataria">
<html>
<head>  
  <script type="text/javascript">
    window.onload = function () {
      var chart = new CanvasJS.Chart("chartContainer", {
          title: {
              text: "<xsl:apply-templates select="tituloGrafico" />",
              fontFamily: "Verdana",
              fontColor: "#FFB70F",
              fontSize: 30
          },
          animationEnabled: true,
          axisY: {
              tickThickness: 0,
              lineThickness: 0,
              valueFormatString: " ",
              gridThickness: 0                    
          },
          axisX: {
              tickThickness: 0,
              lineThickness: 0,
              labelFontSize: 24,
              labelFontColor: "#5a070c"
          },
          data: [
          {
              indexLabelFontSize: 26,
              indexLabelPlacement: "inside",
              indexLabelFontColor: "white",
              indexLabelFontWeight: 600,
              indexLabelFontFamily: "Verdana",
              color: "#5a070c",
              type: "bar",
              dataPoints: [
              <xsl:for-each select="dados" >
                  { y: <xsl:apply-templates select="valor" />, label: "<xsl:apply-templates select="valor" />", indexLabel: "<xsl:apply-templates select="titulo" />" },
              </xsl:for-each>
              ]
          }
          ]
      });

      chart.render();
    }
  </script>
  <script src="js/canvasjs.min.js"></script>
</head>
  <body style="font-family: Verdana; color: #5a070c; text-align: center; font-size: 14px;">
    <div style="font-size: 34px;"><strong><xsl:apply-templates select="sobre/nome" /></strong></div>
    <xsl:apply-templates select="sobre/site" /><br /><br />

    <div id="chartContainer" style="height: 450px; width: auto;"></div>
    <br />
    <input type='button' value='Gerar novo relatório' style="font-family: Verdana; text-align: center; font-size: 14px;" onclick="javascript: window.location.href = 'index.htm'" />
  </body> 
</html>
</xsl:template>

</xsl:stylesheet> 