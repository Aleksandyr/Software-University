<!DOCTYPE html>
<?php
if(isset($_POST['tags'])){
    $tagText = explode(', ', $_POST['tags']);
    $content = '<div id="reslut">';
    for($i = 0; $i < count($tagText); $i++){
        $content .= '<p>' . "$i : $tagText[$i]" . '</p>';
    }
    $content .= '</div>';
}
?>
<html>
<head>
    <title>Print Tags</title>
</head>
<body>
    <form action="" method="post">
        <label>Enter a tags: </label><br />
        <input type="text" name="tags" required="true"/>
        <input type="submit" name="submitBtn" value="Submit"/>
    </form>
    <?php
    if(isset($content))
        echo $content;
    ?>
</body>
</html>