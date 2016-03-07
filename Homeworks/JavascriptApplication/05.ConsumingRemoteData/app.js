'use strict';

var app = app || {};

(function(scope){
    var APP_ID, RESOURCE_URL, USER_AUTH;

    var listAllBooks, addBook, editBook,
        errorMsg, successMsg,
        showEditForm, deleteBook;

    RESOURCE_URL = 'http://baas.kinvey.com';
    APP_ID = 'kid_-ywUA-g7k-';
    USER_AUTH = 'cGVzaG86MTIzNA==';

    successMsg = $('.messages .success');
    errorMsg = $('.messages .error');

    $(function(){
        listAllBooks();
    });

    listAllBooks = function(){
        return $.ajax({
            headers: {
                'Authorization' : 'Basic ' + USER_AUTH
            },
            url: RESOURCE_URL + '/appdata/' + APP_ID + '/books',
            type: 'GET',
            contentType: 'application/json',
            success: function(data){
                successMsg
                    .html('', data.name + 'successfully listed')
                    .show()
                    .fadeOut(2000);

                $('#books').text('');

                for(var b in data){
                    var book = data[b];
                    var bookRow = $('<tr>');
                    bookRow.append($('<td id="title">').text(book.title));
                    bookRow.append($('<td id="author">').text(book.author));
                    bookRow.append($('<td id="isbn">').text(book.isbn));
                    bookRow.append($('<td>').html($('<a href="#" data-id="' + book._id + '">').text('Edit').on('click', showEditForm)));
                    bookRow.append($('<td>').html($('<a href="#" data-id="' + book._id + '">').text('Delete').on('click', deleteBook)));
                    bookRow.appendTo($('#books'));
                }
            },
            error: function(err){
                errorMsg
                    .html('Error happened: ' + err)
                    .show()
                    .fadeOut(2000);
            }
        });
    };

    deleteBook = function(e){
        var bookId = $(this).attr('data-id');

        $.ajax({
            headers: {
                'Authorization' : 'Basic ' + USER_AUTH
            },
            url: RESOURCE_URL + '/appdata/' + APP_ID + '/books/' + bookId,
            type: 'DELETE',
            success: function(data){
                successMsg.html('' + data.name + ' successfully deleted')
                    .show()
                    .fadeOut(2000);
                listAllBooks();
            },
            error: function(err){
                errorMsg
                    .html('Error happened: ' + err)
                    .show()
                    .fadeOut(2000);
            }
        });
    };

    showEditForm = function(){
        var currentRow = $(this).parent().parent();
        var bookTitle = currentRow.find('#title').text();
        var bookAuthor = currentRow.find('#author').text();
        var bookIsbn = currentRow.find('#isbn').text();
        var bookId = $(this).attr('data-id');

        $('#book-title').val(bookTitle);
        $('#book-author').val(bookAuthor);
        $('#book-isbn').val(bookIsbn);
        $('#book-id').val(bookId);
        $('#book-form').fadeIn();
    }
}(app));