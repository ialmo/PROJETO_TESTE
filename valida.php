<?php
/*
AUTOR: LEONARDO HENRIQUE CERQUEIRA
*/
require 'sessao.php';
require 'base/con_mysql.php';

##FUNCOES PHP##
function criaTexto($file, $base, $cabecalho, $texto, $titulo) {
    if (file_exists($file)):
        $file = "{$base}/{$titulo}" . time() . ".txt";
        $arq = fopen($file, 'w');
        fwrite($arq, $cabecalho);
        fwrite($arq, $texto);
        fclose($arq);
        return TRUE;
    elseif (!file_exists($file)):
        $file = "{$base}/{$titulo}.txt";
        $arq = fopen($file, 'w');
        fwrite($arq, $cabecalho);
        fwrite($arq, $texto);
        fclose($arq);
        return TRUE;
    else:
        return FALSE;
    endif;
}

$user = $_SESSION['user_user'];
$nome = ucwords(filter_input(INPUT_POST, 'nome'));
$titulo = str_replace(' ', '_', strip_tags((nl2br(filter_input(INPUT_POST, 'titulo'))), "<p><br>"));
$post = filter_input(INPUT_POST, 'send');

$base = getcwd() . "/users/";
$base .= $user;
$file = "{$base}/{$titulo}.txt";
$cabecalho = "Autor: {$nome}\r\nTítulo: {$titulo}\r\n\r\n";
$texto = str_replace('<br />', '', strip_tags((nl2br(filter_input(INPUT_POST, 'text'))), "<p><br>"));

if (!file_exists($base)):
    mkdir($base, 0777);
endif;

if (criaTexto($file, $base, $cabecalho, $texto, $titulo)) {
    $escrever = TRUE;
} else {
    $escrever = FALSE;
}

//GRAVACAO NO BANCO DE DADOS 
if (isset($post)) {
    if (!empty($texto)) {
        $data = date('d/m/Y H:i:s');
        $sqlCreate = "CREATE TABLE IF NOT EXISTS textos_$user (cod INT AUTO_INCREMENT NOT NULL PRIMARY KEY, data VARCHAR(20) NOT NULL , usuario VARCHAR(255) NOT NULL , titulo VARCHAR(255) NOT NULL )";
        $criatabela = mysql_query($sqlCreate) or die(mysql_error());
        $sqlInsert = "INSERT INTO textos_$user (data, usuario, titulo) VALUES ('$data','$user','$titulo')";
        $inserir = mysql_query($sqlInsert);

        if (($inserir == TRUE) && ($escrever == TRUE)) {
            header("Location:index.php?envio=sucesso&#resposta");
        } else {
            header("Location:index.php?envio=erro&#resposta");
        }
    }
}
