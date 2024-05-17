<?php
$ch = curl_init();
$headers  = ['Content-Type: application/json'];
$postData = '{
  "timestamp": "2021-08-17 12:28:54.303142",
  "syntaxRev": "1.1",
  "compatibleRev": "1.1",
  "product": {
    "name": "",
    "revision": "L1",
    "family": "ucpn_shipment",
    "customer": "admin"
  },
  "factory": {
    "name": "",
    "line": "L1",
    "tester": "AutoTest_BE_AOI",
    "user": "snimumuh"
  },
  "panel": {
    "comment": "None",
    "runmode": "Production",
    "timestamp": "2021-08-17 12:28:54.303142",
    "testTime": "0",
    "status": "Passed",
    "dut": {
      "id": "DUMMAYAAPART0001",
      "comment": "",
      "panel": "0",
      "socket": "0",
      "timestamp": "2021-08-17 12:28:54.303142",
      "runmode": "runmode",
      "testTime": "0",
      "status": "Passed",
      "group": {
        "Name": "BTCD",
        "groupIndex": "0",
        "loopIndex": "0",
        "type": "SequenceCall",
        "moduleTime": "0",
        "totalTime": "0",
        "timeStamp": "2021-08-17 12:28:54.303142",
        "status": "Passed",
        "tests": [
          {
            "name": "nGTES-SEQ_VERSION",
            "unit": "ea",
            "hilim": "0",
            "lolim": "0",
            "rule": "EQ",
            "value": "HSW4026ATL2_FLEXCH_BTC_CSW_3.0.2.4_v002A(2).Seq | 79FBCBC15551EA3CC4A66545428C4490 | BTC_PROD",
            "status": "Passed"
          },
          {
            "name": "nGTES-EXE_versions",
            "unit": "ea",
            "hilim": "0",
            "lolim": "0",
            "rule": "EQ",
            "value": "TMMSeq.exe v1.7.79; Windows 8 (or Windows Server 2012) / v6.2.9200 / ; SRIWDTCH0159",
            "status": "Passed"
          }
        ]
      }
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

echo $result;
?>