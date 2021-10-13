function f() {
    let name = document.getElementById("fname").value;
    var nameTag = document.createElement("p");
    var nameText = document.createTextNode(name);
    nameTag.appendChild(nameText);
    var nameElement = document.getElementById("column-studie");
    nameElement.appendChild(nameTag);


    let students = document.getElementById("students").value;
    var studentsTag = document.createElement("p");
    var studentsText = document.createTextNode(students);
    studentsTag.appendChild(studentsText);
    var studentsElement = document.getElementById("column-beschrijving");
    studentsElement.appendChild(studentsTag);

    let email = document.getElementById("email").value;
    var emailTag = document.createElement("p");
    var emailText = document.createTextNode(email);
    emailTag.appendChild(emailText);
    var emailElement = document.getElementById("column-email");
    emailElement.appendChild(emailTag);
}