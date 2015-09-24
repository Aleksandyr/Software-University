<?php

class AuthorsController extends BaseController {
    private $db;

    public function onInit(){
        $this->title = "Authors";
        $this->db = new AuthorsModel();
    }

    public function index(){
        $this->authors = $this->db->getAll();
    }

    public function create(){
        if($this->isPost){
            $name = $_POST['author_name'];
            $this->db->createAuthor($name);
            $this->redirect('authors');
        }
    }

    public function delete($id){
        $this->db->deleteAuthor($id);
        $this->redirect('authors');
    }
}