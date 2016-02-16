var todo = (function () {
    var Container  = (function () {
		function Container (name) {
			this._name  = name;
		}

		Container.prototype.addItem = function (buttonId) {
			buttonId = buttonId.substr(buttonId.indexOf('_') + 1);

			var itemDiv = document.createElement('div');
			itemDiv.className = 'itemDiv';

			var checkBox = document.createElement('input');
			checkBox.type = 'checkbox';
			checkBox.name = 'name';
			checkBox.value = 'value';
			checkBox.className = 'checkBox';
			checkBox.addEventListener('click', function() {
				if (this.nextSibling.style.backgroundColor == 'lightgreen') {
					this.nextSibling.style.backgroundColor = 'white';
				} else {
					this.nextSibling.style.backgroundColor = 'lightgreen';
				}
			}, false);
			itemDiv.appendChild(checkBox);

			var text = document.createElement('p');
			text.textContent = document.getElementById('sectionInput_' + buttonId).value;
			text.id = 'itemText';
			itemDiv.appendChild(text);

			document.getElementById('itemContainer_' + buttonId).appendChild(itemDiv);
		}

		Container.prototype.addSection = function () {
			var sectionsCount = document.querySelectorAll('.sectionWrap').length;
		
			var section = document.createElement('div');
			section.className = 'sectionWrap';
			section.id = 'section_' + sectionsCount;

			var h2 = document.createElement('p');
			h2.textContent = document.getElementById('inputId').value;
			h2.id = 'sectionTitle';
			section.appendChild(h2);

			var itemContainer = document.createElement('div');
			itemContainer.id = 'itemContainer_' + sectionsCount;
			itemContainer.className = 'itemContainer';
			section.appendChild(itemContainer);

			var input = document.createElement('input');
			input.id =  'section' + 'Input_' + sectionsCount;
			input.className = 'itemInput';
			input.setAttribute('placeholder','Add item..');
			section.appendChild(input);

			var button = document.createElement('button');
			button.id = 'itemSubmitButton_' + sectionsCount;
			button.className = 'itemSubmitButton';
			button.textContent = '+';
			button.addEventListener('click', function() {
				todoList.addItem(button.id);
			}, false);
			section.appendChild(button);
			
			document.getElementById('sections').appendChild(section);
		}

		Container.prototype.addToDom = function () {
			var div = document.createElement('div');
			div.id = 'todoContainer'; 

			var comment = this._name;
			var title = document.createElement('p');
			title.textContent = comment;
			title.id = 'titleId';
			div.appendChild(title);

			var sections = document.createElement('div');
			sections.id = 'sections';
			div.appendChild(sections);
			
			var label = document.createElement('label');
			label.id = 'sectionLabel';
			label.textContent = 'Enter section name: ';
			div.appendChild(label);
			

			var input = document.createElement('input');
			input.type = 'text';
			input.id = 'inputId';
			input.setAttribute('placeholder','Title');
			div.appendChild(input);

			var button = document.createElement('button');
			button.id = 'sectionSubmitButton';
			button.textContent = 'New section';
			button.addEventListener('click', todoList.addSection, false);
			div.appendChild(button);

			document.body.appendChild(div);
		}

		return Container
	}());

	return {
		Container: Container
	};
}());

var todoList = new todo.Container('Tuesday TODO list');
todoList.addToDom();