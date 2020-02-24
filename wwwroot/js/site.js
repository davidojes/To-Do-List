﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var userInput = "";
var inputIsValid = false;
var editValue = "";
var newTaskListItem;

// get tasklist and items
var taskListItems = document.getElementsByClassName("taskListItem");
taskListItems = Array.from(taskListItems);
taskListItems.forEach(setupTaskListItems);

// get and setup all delete buttons
var deleteButtons = document.getElementsByClassName("delete-link");
deleteButtons = Array.from(deleteButtons);
deleteButtons.forEach(setupDeleteButton);

// get and setup all checkboxes
//var checkBoxes = document.querySelectorAll("input[type='checkbox']");
var checkBoxes = document.getElementsByClassName("checkbox");
checkBoxes = Array.from(checkBoxes);
checkBoxes.forEach(setupCheckBox);

// get and setup all hidden checkboxes
var hiddenCheckBoxes = document.getElementsByClassName("hidden-checkbox");
hiddenCheckBoxes = Array.from(hiddenCheckBoxes);
hiddenCheckBoxes.forEach(setupHiddenCheckBox);

/* these are all setup related functions */

function setupTaskListItems(item) {

  item.addEventListener("click", listItemEventListeners);
}

function listItemEventListeners() {
  let editBox = this.parentElement.parentElement.getElementsByClassName("edit-div")[0];
  editBox.style.display = "block";
  editValue = this.innerHTML.trim();

  let textArea = this.parentElement.parentElement.getElementsByClassName("edit-input-area")[0];
  textArea.value = editValue;
  textArea.style.height = this.offsetHeight + "px";

  this.parentElement.remove();
  checkBoxes.forEach(function (item) { item.disabled = true; });
  deleteButtons.forEach(function (item) { item.disabled = true; });
  // to be moved to var at the top of the file
  let addTaskButton = document.getElementById("addTaskButton");
  addTaskButton.disabled = true;
  let inputBox = document.getElementById("inputBox");
  inputBox.disabled = true;

  taskListItems.forEach(function (item) {
    item.removeEventListener("click", listItemEventListeners);
    item.style.cursor = "default";
  });
}

// a function that adds delete symbol to delete buttons
function setupDeleteButton(item) {
  item.value = "\u00D7";
}

function setupHiddenCheckBox(item) {
  if (item.className == "isTicked hidden-checkbox")
    item.checked = true;
}

// a function that checks off complete task on load
// it also adds an onclick event listener that strikes out its paired list item
function setupCheckBox(item) {
  if (item.className == "isTicked checkbox")
    item.checked = true;

  item.addEventListener("click", function () {
    let pairedItem = this.parentElement.parentElement.getElementsByClassName("taskListItem")[0];
    let li = this.parentElement.parentElement.parentElement;
    let editForm = li.getElementsByClassName("edit-bar")[0];
    let editFormCheckBox = editForm.getElementsByClassName("checkbox")[0];
    editFormCheckBoxHidden = editForm.getElementsByClassName("hidden-checkbox")[0];
    console.log(editFormCheckBoxHidden.checked);
    let editFormTextArea = editForm.getElementsByClassName("edit-input-area")[0];
    editFormTextArea.value = pairedItem.innerHTML;

    if (this.checked == false) {
      this.className = "checkbox";
      this.checked = false;
      pairedItem.className = "taskListItem";
      // for edit form
      editFormCheckBox.className = "checkbox";
      editFormCheckBox.checked = false;
      editFormCheckBoxHidden.checked = false;
      editFormCheckBoxHidden.className = "hidden-checkbox";
    }
    else {
      this.className = "isTicked checkbox";
      this.checked = true;
      pairedItem.className = "completed-task taskListItem";
      // for edit form
      editFormCheckBox.className = "isTicked checkbox";
      editFormCheckBox.checked = true;
      editFormCheckBoxHidden.checked = true;
      editFormCheckBoxHidden.className = "isTicked hidden-checkbox";
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
    setupTaskListItems(newTaskListItem);
    this.parentElement.parentElement.submit();
  }
}

// a function that deletes a list item
function deleteTask() {
  this.parentElement.remove();
}

// a function that checks if user input is valid
function validateInput(input) {
  if (input.trim() != "") {
    inputIsValid = true;
  }

  else (alert("Field can't be blank"));
}
