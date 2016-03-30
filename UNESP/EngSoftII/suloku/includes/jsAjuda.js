$(document).ready(function(){

      $('#imgAjuda').css('display', 'inheirit');
      $('.inicio').css('display', 'none');
      $('.nivel').css('display', 'none');
      $('.jogo').css('display', 'none');
      $('.ranking').css('display', 'none');

      $('#inicio').click(function(){
            if ($('.inicio').css('display') == "none")
            {
                  // Mostra divs inicio
                  $('.inicio').show('fast');

                  // Esconde outras divs
                  $('.imgAjuda').hide('fast');
                  $('.nivel').hide('fast');
                  $('.jogo').hide('fast');
                  $('.ranking').hide('fast');
            }
            else
            {
                  $('.inicio').hide('fast');
                  $('.imgAjuda').show('fast');         
            }                 
      });

      $('#nivel').click(function(){
            if ($('.nivel').css('display') == "none")
            {
                  // Mostra divs inicio
                  $('.nivel').show('fast');

                  // Esconde outras divs
                  $('.imgAjuda').hide('fast');
                  $('.inicio').hide('fast');
                  $('.jogo').hide('fast');
                  $('.ranking').hide('fast');
            }
            else
            {
                  $('.nivel').hide('fast');
                  $('.imgAjuda').show('fast');         
            }                 
      });

      $('#jogo').click(function(){
            if ($('.jogo').css('display') == "none")
            {
                  // Mostra divs inicio
                  $('.jogo').show('fast');

                  // Esconde outras divs
                  $('.imgAjuda').hide('fast');
                  $('.inicio').hide('fast');
                  $('.nivel').hide('fast');
                  $('.ranking').hide('fast');
            }
            else
            {
                  $('.jogo').hide('fast');
                  $('.imgAjuda').show('fast');         
            }                 
      });

      $('#ranking').click(function(){
            if ($('.ranking').css('display') == "none")
            {
                  // Mostra divs inicio
                  $('.ranking').show('fast');

                  // Esconde outras divs
                  $('.imgAjuda').hide('fast');
                  $('.inicio').hide('fast');
                  $('.nivel').hide('fast');
                  $('.jogo').hide('fast');
            }
            else
            {
                  $('.ranking').hide('fast');
                  $('.imgAjuda').show('fast');         
            }                 
      });
});  