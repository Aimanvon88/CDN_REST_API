<?php
$sn = $_GET['sn'];
$station = $_GET['station'];
$user = $_GET['user'];
$ch = curl_init();
date_default_timezone_set("Asia/Kuala_Lumpur");
$timestamp = date('Y-m-d H:m:i.s');
$headers  = ['Content-Type: application/json'];
$postData = '{
  "timestamp": "'.$timestamp.'",
  "syntaxRev": "1.1",
  "compatibleRev": "1.1",
  "product": {
    "name": "",
    "revision": "",
    "family": "",
    "customer": ""
  },
  "factory": {
    "name": "",
    "line": "BE_AOI 1",
	"fixture": "MakerRay",
    "tester": "'.$station.'",
    "user": "'.$user.'"
  },
  "panel": {
    "comment": "None",
    "runmode": "Production",
    "timestamp": "'.$timestamp.'",
    "testTime": "0",
    "status": "Passed",
    "dut": {
      "id": "'.$sn.'",
      "comment": "",
      "panel": "0",
      "socket": "0",
      "timestamp": "'.$timestamp.'",
      "runmode": "runmode",
      "testTime": "0",
      "status": "Passed"
    }
  }
}';
curl_setopt($ch, CURLOPT_URL,"http://sninte813:1111/FFTester_SenaiLive/api/SaveTestResult");
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $postData);           
curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
$result     = curl_exec ($ch);
$statusCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);

$content = $result;
//json object.
//$jsonArray = json_decode($contents,true);
//$result = $jsonArray['value'];
echo $content;
?>