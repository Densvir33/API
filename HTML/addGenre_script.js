fetch("https://localhost:44387/api/Genre", {
    method: "GET"
})
    .then(response => response.json())
    .then(json => {
        for (var i = 0; i < json.length; i++) {
            document.getElementById("genre").innerHTML += `
            <button class="btn">
                <div class="btn-div">
                    <div>
                        <p>Name: ${json[i].name}</p>
                    </div>
                    <div class="btn-div">
                        <button class="btn-crud" onclick="Edit()">Edit</button>
                        <button class="btn-crud" onclick="Delete()">Delete</button>
                    </div>
                </div>
            </button>
            `
        }
    })
    .catch(err => console.log(err))

function AddGenre() {
    var data = {
        Name: document.getElementById("name").value, 
    }
    console.log(data);
    fetch("https://localhost:44387/api/Genre/AddGenre", {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(res => res.json())
        .catch(err => console.log(err))
    document.getElementById("name").value = "";
}