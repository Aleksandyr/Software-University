<!DOCTYPE html>
<html>
<head>
    <title>Information Table</title>
</head>
<style>
    form{
        width: 80px;
    }
</style>
<body>
    <form action="07.GetFormData.php" method="get">
        <input type="text" placeholder="Name..." name="name" />
        <input type="number" placeholder="age..." name="age" />
        <input type="radio" name="sex" value="male" checked/>
        <label>Male</label>
        <input type="radio" name="sex" value="female"/>
        <label>Female</label>
        <input type="submit" value="submit" />
    </form>
    <?php
        if(isset($_GET['name'], $_GET['age'], $_GET['sex'])){
    ?>
            <p>My name is <?= htmlentities($_GET['name'])?>. I am <?= htmlentities($_GET['age']) ?> years old.
                I am <?= htmlentities($_GET['sex'])?>
            </p>
    <?php
        }
    ?>
</body>
</html>