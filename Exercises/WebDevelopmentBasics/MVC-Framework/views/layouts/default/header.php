<!DOCTYPE html>
<html>

<head>
    <meta charset="utf8">
    <link rel="stylesheet" href="/content/styles.css">
    <title>
        <?php if(isset($this->title)) echo htmlspecialchars($this->title); ?>
    </title>
</head>

<body>
    <header>
        <a href="/"><img src="/content/images/site-logo.png"></a>
        <ul>
            <li><a href="/">Home</a></li>
            <li><a href="/authors">authors</a></li>
            <li><a href="/books">books</a></li>
        </ul>
    </header>
