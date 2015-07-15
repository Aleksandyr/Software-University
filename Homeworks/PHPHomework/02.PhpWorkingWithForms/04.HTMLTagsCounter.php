<!DOCTYPE html>
<?php
session_start();
?>
<html>
<head>
    <title>HTML tags counter</title>
</head>
<body>
<form action="" method="get">
    <label>Enter a tags: </label><br />
    <input type="text" name="tag" required="true"/>
    <input type="submit" name="submitBtn" value="Submit"/>
</form>
<?php
$tags = array("a", "abbr", "address", "area", "article", "aside", "audio", "b", "base", "bdi", "bdo", "blockquote", "body", "br", "button", "canvas", "caption",
    "cite", "code", "col", "colgroup", "command", "datalist", "dd", "del", "details", "dfn", "div", "dl", "dt", "em", "embed", "fieldset", "figcaption", "figure",
    "footer", "form", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label",
    "legend", "li", "link", "map", "mark", "menu", "meta", "meter", "nav", "noscript", "object", "ol", "optgroup", "option", "output", "p", "param", "pre", "progress",
    "q", "rp", "rt", "ruby", "s", "samp", "script", "section", "select", "small", "source", "span", "strong", "style", "sub", "summary", "sup", "table", "tbody", "td",
    "textarea", "tfoot", "th", "thead", "time", "title", "tr", "track", "u", "ul", "var", "video", "wbr");
if(!isset($_SESSION['score']) || !isset($_SESSION['tagsLeft'])){
    $_SESSION['score'] = 0;
    $_SESSION['tagsLeft'] = $tags;
}
if(isset($_GET['tag'])){
    $tag = mb_strtolower(trim($_GET['tag']));
    if(array_search($tag, $tags) === false){
        echo "<div class=\'info\'>Invalid HTML tag!</div>";
    } else{
        echo "<div class=\'info\'>Valid HTML tag!</div>";

        if(array_search($tag, $_SESSION['tagsLeft']) !== false){
            $_SESSION['score']++;
            $key = array_search($tag, $tags);
            unset($_SESSION['tagsLeft'][$key]);
        }
    }

    echo "<div class=\'info\'>Score: ". $_SESSION['score'] ."</div>";
    if($_SESSION['score'] == count($tags)){
        echo "<div class=\'info\'>You wrote all tags!</div>";
    }
}
?>
</body>
</html>