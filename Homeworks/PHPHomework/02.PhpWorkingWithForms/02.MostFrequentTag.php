<!DOCTYPE html>
<?php
    if(isset($_POST['tags'])){
        $tags = explode(', ', $_POST['tags']);

        $tagCounts = [];
        foreach($tags as $tag){
            if(isset($tagCounts[$tag])){
                $tagCounts[$tag]++;
            } else{
                $tagCounts[$tag] = 1;
            }
        }

        arsort($tagCounts);
        $content = '<div id="result">';
        foreach ($tagCounts as $key => $value) {
            $content .= "<p>$key  : $value " . (($value == 1) ? 'time' : 'times') . "</p>";
        }
        $mostFreqTag = "Most frequent tag is: " . array_keys($tagCounts)[0];
        $content .= "<p>$mostFreqTag</p></div>";
    }
?>
<html>
<head>
    <title>Most frequent number</title>
</head>
<body>
    <form action="" method="post">
        <label>Enter a tags: </label><br />
        <input type="text" name="tags" required="true"/>
        <input type="submit" name="submitBtn" value="Submit"/>
    </form>
    <?php
    if(isset($content, $mostFreqTag)) {
        echo $content;
        ?>
    <?php
    }
    ?>
</body>
</html>