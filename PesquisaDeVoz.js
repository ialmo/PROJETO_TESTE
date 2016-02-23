<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Pesquisa por Query-String (microfone) | Leonardo Cerqueira</title>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body onload="document.getElementById('rect').click()">
    <?php
        //VARIAVEL BOTAO PESQUISAR
        //ATUALIZA A PAGINA
        $botaoPesquisar = "<hr><button style='
                                    padding:10px;
        						    font-family:sans;
        						    font-size:1em;
        						    color:#FFF;
        						    background:#000;
        						    border-radius:10px;'						                    ' 
						    onclick='javascript:location.reload()'> Pesquisar novamente </button>";
    ?>
		<p id="ola">Fale para pesquisar</p>
		<hr>
		<p>Palavras disponíveis:</p>
		<ul>
		    <li>tecnologia</li>
		    <li>artigos</li>
		    <li>notícias</li>
		</ul>
		<br>
		<div id="transcription"></div>
 
		<button id="rect" style="display:none">Fale para pesquisar:</button>
		<?php
			if(isset($_GET['q'])){
				$q = $_GET['q'];
				switch ($q) {
					case 'artigos':
						echo "<h1> ARTIGOS </h1>";
						echo "<ul>";
						echo "<li>Artigo 1</li>";
						echo "<li>Artigo 2</li>";
						echo "<li>Artigo 3</li>";
						echo "</ul>";
						echo $botaoPesquisar;
						break;
					
					case 'notícias':
						echo "<h1> NOTICIAS </h1>";
						echo "<ul>";
						echo "<li>Notícia 1</li>";
						echo "<li>Notícia 2</li>";
						echo "<li>Notícia 3</li>";
						echo "</ul>";
						echo $botaoPesquisar;
						break;

					case 'tecnologia':
						echo "<h1> TECNOLOGIA </h1>";
						echo "<ul>";
						echo "<li>Apple compra Android</li>";
						echo "<li>Bill Gates vai a falência</li>";
						echo "<li>IOS CODE BREAK saiba mais...</li>";
						echo "</ul>";
						echo $botaoPesquisar;
						break;

					default:
						echo "<h1> Desculpe mas não existe resultados para: <span style='color:red'>{$q}</span> </h1>";
						echo $botaoPesquisar;
						break;
				}
			}
		?>
    <script type="text/javascript">
    // Test browser support
      window.SpeechRecognition = window.SpeechRecognition       ||
                                 window.webkitSpeechRecognition ||
                                 null;
 
		//caso não suporte esta API DE VOZ                              
		if (window.SpeechRecognition == null) {
		    if(!window.chrome || window.opr || opr.addons){
	    	    document.getElementById('ola').innerHTML = 'Desculpe o seu navegador não suporta a API de pesquisa de voz'+'<br>'+'Por favor ume o Chrome na versão mais atual!';
		    }
        }else {
        	var input = document.getElementById("input");
            var recognizer = new window.SpeechRecognition();
            var transcription = document.getElementById("transcription");
        	//Para o reconhecedor de voz, não parar de ouvir, mesmo que tenha pausas no usuario
        	recognizer.continuous = true
        	recognizer.onresult = function(event){
        		transcription.textContent = "";
        		for (var i = event.resultIndex; i < event.results.length; i++) {
        			if(event.results[i].isFinal){
        				var qr = transcription.textContent = event.results[i][0].transcript;
        				window.location.href = "?q=" + qr;
        			}else{
		            	transcription.textContent += event.results[i][0].transcript;
        			}
        		}
        	}

        	document.querySelector("#rect").addEventListener("click",function(){
        		try {
		            recognizer.start();
		          } catch(ex) {
		          	alert("error: "+ex.message);
		          }
        	});
        }
    </script>
</body>
</html>
