const uri = 'CDNWebAPI';
let todos = [];

function getItems() {
  fetch("CDNWebAPI/GetAllUser")
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
  const addUsernameTextbox = document.getElementById('add-username');
  const addEmailTextbox = document.getElementById('add-email');
  const addPhoneTextbox = document.getElementById('add-phone');
  const addSkillTextbox = document.getElementById('add-skill');
  const addHobbyTextbox = document.getElementById('add-hobby');

  const item = {
    username: addUsernameTextbox.value.trim(),
    email: addEmailTextbox.value.trim(),
    phone: addPhoneTextbox.value.trim(),
    skill: addSkillTextbox.value.trim(),
    hobby: addHobbyTextbox.value.trim()
  };

  fetch("CDNWebAPI/CreateUser", {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems();
      addUsernameTextbox.value = '';
      addEmailTextbox.value = '';
      addPhoneTextbox.value = '';
      addSkillTextbox.value = '';
      addHobbyTextbox.value = '';
    })
    .catch(error => console.error('Unable to add user.', error));
}

function deleteItem(id) {
  fetch("CDNWebAPI/DeleteUserById/"+`${id}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete user.', error));
}

function displayEditForm(id) {
  const item = todos.find(item => item.id === id);
  
  document.getElementById('edit-id').value = item.id;
  document.getElementById('edit-username').value = item.username;
  document.getElementById('edit-email').value = item.email;
  document.getElementById('edit-phone').value = item.phone;
  document.getElementById('edit-skill').value = item.skill;
  document.getElementById('edit-hobby').value = item.hobby;
    
  document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    username: document.getElementById('edit-username').value.trim(),
    email: document.getElementById('edit-email').value.trim(),
    phone: document.getElementById('edit-phone').value.trim(),
    skill: document.getElementById('edit-skill').value.trim(),
    hobby: document.getElementById('edit-hobby').value.trim()
  };

  fetch("CDNWebAPI/UpdateUserById/"+`${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update user.', error));

  closeInput();

  return false;
}

function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'user' : 'users';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
  const tBody = document.getElementById('todos');
  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach(item => {

    let editButton = button.cloneNode(false);
    editButton.innerText = 'Edit';
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'Delete';
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

    let tr = tBody.insertRow();

    let td = tr.insertCell(0);
    let textNode = document.createTextNode(item.username);
    td.appendChild(textNode);
    
    let td1 = tr.insertCell(1);
    let textNode1 = document.createTextNode(item.email);
    td1.appendChild(textNode1);

    let td2 = tr.insertCell(2);
    let textNode2 = document.createTextNode(item.phone);
    td2.appendChild(textNode2);

    let td3 = tr.insertCell(3);
    let textNode3 = document.createTextNode(item.skill);
    td3.appendChild(textNode3);

    let td4 = tr.insertCell(4);
    let textNode4 = document.createTextNode(item.hobby);
    td4.appendChild(textNode4);

    let td5 = tr.insertCell(5);
    td5.appendChild(editButton);

    let td6 = tr.insertCell(6);
    td6.appendChild(deleteButton);
  });

  todos = data;
}
