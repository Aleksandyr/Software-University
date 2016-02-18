var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}

			var moviesNodes = Array.prototype.slice.call(moviesContainer.firstElementChild.childNodes);
			moviesNodes.forEach(function(node){
				node.addEventListener('click', function(ev){

					//clean the details container
					while (detailsContainer.firstChild){
						detailsContainer.removeChild(detailsContainer.firstChild);
					}

					if(ev.target.tagName = 'LI'){
						var id = this.getAttribute('data-id');

						var movie = genre.getMovies().filter(function(movie){
							return movie._id == id;
						})[0];

						var actors = movie.getActors();
						var reviews = movie.getReviews();

						var actorFragment = document.createDocumentFragment();
						var actorH3 = document.createElement("h3");
						actorH3.innerHTML = 'Actors';
						var actorsUl = document.createElement('ul');
						actors.forEach(function(actor){
							var li = document.createElement('li');
							var h4 = document.createElement('h4');
							h4.innerHTML = actor.name;
							var p = document.createElement('p');
							p.innerHTML = '<strong>Bio: </strong>' + actor.bio + '</br>' + '<strong>Born: </strong>' + actor.born;

							li.appendChild(h4);
							li.appendChild(p);

							actorsUl.appendChild(li);
						});

						actorFragment.appendChild(actorH3);
						actorFragment.appendChild(actorsUl);

						var reviewFragment = document.createDocumentFragment();
						var reviewH3 = document.createElement('h3');
						reviewH3.innerHTML = 'Reviews';
						var reviewUl = document.createElement('ul');
						reviews.forEach(function(review){
							var li = document.createElement('li');
							var	h4 = document.createElement('h4');
							var button = document.createElement('button');
							var p = document.createElement('p');

							h4.innerHTML = review.author;
							p.innerHTML = '<strong>Bio: </strong>' + review.content + '</br>' + '<strong>Born: </strong>' + review.date;
							button.value = 'Delete';
							button.innerHTML = 'Delete review';

							button.addEventListener('click', function (){
								movie.deleteReviewById(review._id);
								reviewUl.removeChild(li);
							});

							li.appendChild(h4);
							li.appendChild(p);
							li.appendChild(button);

							reviewUl.appendChild(li);
						});

						reviewFragment.appendChild(reviewH3);
						reviewFragment.appendChild(reviewUl);

						detailsContainer.appendChild(actorFragment);
						detailsContainer.appendChild(reviewFragment);
					}
				});
			});
		});

		// Task 2 - Add event listener for movies boxes

		// Task 3 - Add event listener for delete button (delete movie button or delete review button)
	}

	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	scope.loadHtml = loadHtml;
}(imdb));