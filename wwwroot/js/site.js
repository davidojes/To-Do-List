// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.



var userInput = "";
var inputIsValid = false;

// get tasklist and items
var taskListItems = document.getElementsByClassName("taskListItem");
//var taskListItems = taskList.children;
// convert the children of the task list into an array
taskListItems = Array.from(taskListItems);
// call the setup function on each task list item
taskListItems.forEach(setupTaskListItems);
var newTaskListItem;

// get and setup all delete buttons
var deleteButtons = document.getElementsByClassName("delete-link");
deleteButtons = Array.from(deleteButtons);
deleteButtons.forEach(setupDeleteButton);

// get and setup all checkboxes
var checkBoxes = document.querySelectorAll("input[type='checkbox']");
checkBoxes = Array.from(checkBoxes);
checkBoxes.forEach(setupCheckBox);

// get and set up all edit buttons
var editButtons = document.getElementsByClassName("edit-button");
editButtons = Array.from(editButtons);
editButtons.forEach(setupEditButton);



/* these are all setup related functions */

// a function that attaches an onclick event listener to each list item
function setupTaskListItems(item) {

  item.addEventListener("click", listItemEventListeners);
}

function listItemEventListeners() {

  let pairedItem = item.parentElement.children[0];
  let li = item.parentElement.parentElement;
  let editForm = li.getElementsByClassName("edit-bar")[0];
  let editFormCheckBox = editForm.getElementsByClassName("checkbox")[0];

  if (item.className == "completed-task taskListItem") {
    item.className = "taskListItem";
    pairedItem.checked = false;
    pairedItem.className = "checkbox"

    // for edit form
    editFormCheckBox.className = "checkbox";
    editFormCheckBox.checked = false;
  }
  else {
    item.className = "completed-task taskListItem";
    pairedItem.checked = true;
    pairedItem.className = "isTicked checkbox"

    // for edit form
    editFormCheckBox.className = "isTicked checkbox";
    editFormCheckBox.checked = true;
  }

  editForm.submit();
}

// a function that enables each edit button to show the edit form
function setupEditButton(editButton) {
  editButton.addEventListener("click", editButtonEventListeners);
}

function editButtonEventListeners() {
  this.parentElement.children[0].style.display = "none";
  this.parentElement.children[1].style.display = "none";
  let editBox = this.parentElement.getElementsByClassName("edit-bar")[0];
  editBox.style.display = "block";
  editButtons.forEach(function (item) { item.disabled = true; });
  checkBoxes.forEach(function (item) { item.disabled = true; });
  deleteButtons.forEach(function (item) { item.disabled = true; });
  taskListItems.forEach(function (item) {
    item.removeEventListener("click", listItemEventListeners);
    console.log(item);
  });
}
// a function that adds delete symbol to buttons
function setupDeleteButton(item) {
  item.value = "\u00D7";
}

// a function that checks off complete task on load
// it also adds an onclick event listener that strikes out its paired list item
function setupCheckBox(item) {
  if (item.className == "isTicked checkbox")
    item.checked = true;

  item.addEventListener("click", function () {
    let pairedItem = this.parentElement.children[1];
    let li = this.parentElement.parentElement;
    let editForm = li.getElementsByClassName("edit-bar")[0];
    let editFormCheckBox = editForm.getElementsByClassName("checkbox")[0];

    if (this.checked == false) {
      this.className = "checkbox";
      this.checked = false;
      pairedItem.className = "taskListItem";
      // for edit form
      editFormCheckBox.className = "checkbox";
      editFormCheckBox.checked = false;
    }
    else {
      this.className = "isTicked checkbox";
      this.checked = true;
      pairedItem.className = "completed-task taskListItem";
      // for edit form
      editFormCheckBox.className = "isTicked checkbox";
      editFormCheckBox.checked = true;
    }

    editForm.submit();
  });
}


/* these are all feature related functions */

// a function that adds the text in the input box to the task list
function addTask() {
  userInput = document.getElementById("inputBox").value;
  validateInput(userInput);

  if (inputIsValid) {
    newTaskListItem = document.createElement("li");
    taskList.appendChild(newTaskListItem);
    newTaskListItem.innerHTML = userInput;
    taskListItemSetup(newTaskListItem);
  }
}

// a function that deletes a list item
function deleteTask() {
  this.parentElement.remove();
}

// a function that checks if user input is valid
function validateInput(input) {
  if (input.trim() != "") {
    console.log("x")
    inputIsValid = true;
  }

  else (alert("You need to enter some text"));
}
