document.addEventListener("DOMContentLoaded", function () {
    // Movie Dropdown
    fetch('/Movies/GetMovieTitles')
        .then(response => response.json())
        .then(data => {
            const dropdown = document.getElementById('movieDropdown');
            if (dropdown) {
                data.forEach(title => {
                    const option = document.createElement('option');
                    option.value = title;
                    option.text = title;
                    dropdown.appendChild(option);
                });
            }
        })
        .catch(error => console.error('Error fetching movie titles:', error));

    if (document.getElementById('movieDropdown')) {
        document.getElementById('movieDropdown').addEventListener('change', function () {
            const selectedTitle = this.value;
            if (selectedTitle) {
                fetch(`/Movies/GetMovieDetails?title=${encodeURIComponent(selectedTitle)}`)
                    .then(response => response.json())
                    .then(data => {
                        document.getElementById('imdbLink').innerHTML = `<a href="${data.IMBDLink}" target="_blank">${data.IMBDLink}</a>`;
                        document.getElementById('genre').textContent = data.Genre;
                        document.getElementById('yearOfRelease').textContent = data.YearOfRelease;
                        document.getElementById('seeReviewsButton').style.display = 'block'; // Unhide the button
                    })
                    .catch(error => console.error('Error fetching movie details:', error));
            } else {
                document.getElementById('imdbLink').textContent = '';
                document.getElementById('genre').textContent = '';
                document.getElementById('yearOfRelease').textContent = '';
                document.getElementById('seeReviewsButton').style.display = 'none'; // Hide the button again
            }
        });
    }

    // Actor Dropdown
    fetch('/Actors/GetActorNames')
        .then(response => response.json())
        .then(data => {
            const dropdown = document.getElementById('actorDropdown');
            if (dropdown) {
                data.forEach(name => {
                    const option = document.createElement('option');
                    option.value = name;
                    option.text = name;
                    dropdown.appendChild(option);
                });
            }
        })
        .catch(error => console.error('Error fetching actor names:', error));

    if (document.getElementById('actorDropdown')) {
        document.getElementById('actorDropdown').addEventListener('change', function () {
            const selectedName = this.value;
            if (selectedName) {
                fetch(`/Actors/GetActorDetails?name=${encodeURIComponent(selectedName)}`)
                    .then(response => response.json())
                    .then(data => {
                        console.log('Fetched Data:', data);
                        document.getElementById('imdbLink').innerHTML = `<a href="${data.IMDBLink}" target="_blank">${data.IMDBLink}</a>`;
                        document.getElementById('gender').textContent = data.Gender;
                        document.getElementById('age').textContent = data.Age;
                        document.getElementById('seeTweetsButton').style.display = 'block'; // Unhide the button
                    })
                    .catch(error => console.error('Error fetching actor details:', error));
            } else {
                document.getElementById('imdbLink').textContent = '';
                document.getElementById('gender').textContent = '';
                document.getElementById('age').textContent = '';
                document.getElementById('seeTweetsButton').style.display = 'none'; // Hide the button again
            }
        });
    }
});

