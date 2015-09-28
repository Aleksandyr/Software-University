<h1>Hello, <?= $data->getUsername(); ?></h1>

<?php if(isset($_GET['error'])): ?>
    <h2>An error occured</h2>
<?php elseif(isset($_GET['success'])): ?>
    <h2>Successfully update profile</h2>
<?php endif; ?>

<h3>
    Resources:
    <p>Gold: <?= $data->getGold(); ?></p>
    <p>Gold: <?= $data->getFood(); ?></p>
</h3>

Go to:
<div class="menu">
    <a href="buildings.php">Buildings</a>
</div>

<form>
    <div>
        <input type="text" name="username" value="<?= $data->getUsername(); ?>">
        <input type="password" name="password">
        <input type="password" name="confirm">
        <input type="submit" name="edit" value="Edit">
    </div>
</form>