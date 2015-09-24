<h1><?= htmlspecialchars($this->title) ?></h1>

<table>
    <tr>
        <td>ID</td>
        <td>Name</td>
        <td>Action</td>
    </tr>
    <?php foreach($this->authors as $author) : ?>
        <tr>
            <td><?= $author['id'] ?></td>
            <td><?= htmlspecialchars($author['name'] )?></td>
            <td><a href="/authors/delete/<?= $author['id'] ?>">[Delete]</a></td>
        </tr>
    <?php endforeach ?>
</table>

<a href="/authors/create">[New]</a>