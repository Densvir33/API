fetch("https://localhost:44387/api/Films", {
    method: "GET"
})
    .then(response => response.json())
    .then(json => {
        console.log(json)
        var result=json.resultCollection;
        for (var i = 0; i < result.length; i++) {
            document.getElementById("films").innerHTML += `
            <button class="btn">
                <div class="btn-div">
                    <div>
                        <p>Name: ${result[i].name}</p>
                        <p>Year: ${result[i].year}</p>
                        <p>Genre: ${result[i].genreName}</p>
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

    function AddFilms() {
        var data = {
            Name: document.getElementById("name").value,
            Year: parseInt(document.getElementById("year").value),
            GenreName: document.getElementById("genre").value
        }
        console.log(data);
        fetch("https://localhost:44387/api/Films/AddFilm", {
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
        document.getElementById("year").value = "";
        document.getElementById("genre").value = null;
    }