<?php
    if($_SERVER['REQUEST_METHOD'] == 'GETW'){
        header('HTTP/1.0 405 Method Not Allowed');
        addOnSession('status', 405);
        addOnSession('info', 'Method Not Allowed');
    }
    else{
        if(isset($_REQUEST['version']))
        {
            addEntry($_REQUEST['version']);
        }
        else {
            error400();
        }
    }
    echo json_encode(getSession());

    function error400(){
        header('HTTP/1.0 400 Bad Request');
        addOnSession('status', 400);
        addOnSession('info', 'Missing Parameter');
    }

    function addOnSession($parameter, $value){ $_SESSION['result'][$parameter] = $value; }
    function getSession(){ if(!isset($_SESSION['result'])) return null ; else { if($_SESSION['result'] != '') return $_SESSION['result']; }; }

    function addEntry($version){
        if($version == ''){
            error400();
        }   
        else {
            // TODO
        }
    }