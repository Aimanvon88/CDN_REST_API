<?php
$sn = $_GET['sn'];
$station = $_GET['station'];
$user = $_GET['user'];
$postdata = http_build_query(
    array(
        'SerialNumber' => $sn,
        'StationName' => $station,
		'userId' => $user
    )
);

$opts = array('http' =>
    array(
        'method'  => 'POST',
        'header'  => 'Content-Type: application/x-www-form-urlencoded',
        'content' => $postdata
    )
);

//$opts = array('http' =>
//    array(
//        'method'  => 'POST',
//        'header'  => 'Content-Type: application/x-www-form-urlencoded',
//        'content' => $postdata
//    )
//);


$context  = stream_context_create($opts);

$result = file_get_contents('http://sninte813:1111/FFTester_SenaiLive/api/GetUnitInfo', false, $context);
//$result = file_get_contents('http://sninte813:1111/FFTester_SenaiLive/api/SaveTestResult', false, $context);

echo $result;
?>