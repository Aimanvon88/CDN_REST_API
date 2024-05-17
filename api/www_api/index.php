<html>
<p>Serial Number : <input id="sn" /> </p>
<p>Station Name : <input id="station" /> </p>
<p>User Id : <input id="user" /> </p>
<button onclick="loadDoc()">Send</button> | <button onclick="save()">Save</button><button onclick="clearTable()">Reset</button>
<table id="live_folder">
</table>


<script>
function loadDoc() {
  const xhttp = new XMLHttpRequest();
  var table = document.getElementById("live_folder");
  var row = table.insertRow(0);
  var cell1 = row.insertCell(0);

var sn = document.getElementById("sn").value;
var station = document.getElementById("station").value;
var user = document.getElementById("user").value;

  xhttp.onload = function() {
    //document.getElementById("demo").innerHTML = this.responseText;
	  cell1.innerHTML = this.responseText;
  }
  xhttp.open("GET", "api.php?sn=" + sn +"&station=" + station + "&user=" + user);
  xhttp.send();
}

function save() {
  const xhttp = new XMLHttpRequest();
  var table = document.getElementById("live_folder");
  var row = table.insertRow(0);
  var cell1 = row.insertCell(0);

var sn = document.getElementById("sn").value;
var station = document.getElementById("station").value;
var user = document.getElementById("user").value;

  xhttp.onload = function() {
    //document.getElementById("demo").innerHTML = this.responseText;
	  cell1.innerHTML = this.responseText;
  }
  xhttp.open("GET", "save.php?sn=" + sn +"&station=" + station + "&user=" + user);
  xhttp.send();
}

function clearTable() {
	var table = document.getElementById("live_folder");
	table.innerHTML = '';
	
}
</script>
</html>
