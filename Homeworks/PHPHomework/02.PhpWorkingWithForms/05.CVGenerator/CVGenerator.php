<?php
session_start();
?>

<?php
function validateFields(){
    $error = false;
    $namesPattern = '/^[A-za-z]{2,20}$/';
    $phoneNumPatter = '/^0[\d]+$/';
    $companyNamePattern = '/^[A-za-z0-9]+$/';
    $emailPattern = '/^([a-zA-Z]+)\@([a-zA-Z]+)\.([a-z]{2,3})$/';

    if(isset($_POST['submit'])){
        if(!preg_match($namesPattern, $_POST['fName'])){
            echo "<div class=\'error\'>Invalid first name</div>";
            $error = true;
        }

        if(!preg_match($namesPattern, $_POST['lName'])){
            echo "<div class=\'error\'>Invalid last name</div>";
            $error = true;
        }

        if(!preg_match($emailPattern, $_POST['email'])){
            echo "<div class=\'error\'>Invalid email</div>";
            $error = true;
        }

        if(!preg_match($phoneNumPatter, $_POST['phoneNumber'])){
            echo "<div class=\'error\'>Invalid phone number</div>";
            $error = true;
        }

        if(!preg_match($companyNamePattern, $_POST['companyName'])) {
            echo "<div class=\'error\'>Invalid company name</div>";
            $error = true;
        }
        foreach ($_POST['languages'] as $language) {
            if(!preg_match($namesPattern, $language)){
                echo "<div class=\'error\'>Invalid language name</div>";
                $error = true;
                break;
            }
        }
    }

    return !$error;
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
    <script type="text/javascript" src="script.js"></script>
</head>
<body>
<?php
if($_POST && validateFields()){
    $_SESSION = $_POST;
    header("location: CVResult.php");
}
?>
<form method="post">
    <fieldset>
        <legend>Personal information</legend>
        <div id="inner-fieldset1-width">
            <input type="text" name="fName" required="true" placeholder="First Name"/>
            <input type="text" name="lName" required="true" placeholder="Last Name"/>
            <input type="text" name="email" required="true" placeholder="Email"/>
            <input type="number" name="phoneNumber" required="true" placeholder="Phone number 0..."/>
            <label for="female">Female</label>
            <input type="radio" name="gender" value="female" id="female"/>
            <label for="male">Male</label>
            <input type="radio" name="gender" value="male" id="male"/>
            <label for="birthDate">Birth Date</label>
            <input type="date" name="birthDate" id="birthDate" />
            <label for="nationality">Birth Date</label>
            <select name="nationality" id="nationality">
                <option value="bulgarian">Bulgarian</option>
                <option value="indian">Indian</option>
                <option value="american">American</option>
            </select>
        </div>
    </fieldset>
    <fieldset>
        <legend>Last Work Position</legend>
        <div id="inner-fieldset2-width">
            <label for="companyName">Company name</label>
            <input type="text" name="companyName" id="companyName"/><br />
            <label for="workFromDate">From</label>
            <input type="date" name="workFromDate" id="workFromDate"/><br />
            <label for="workToDate">To</label>
            <input type="date" name="workToDate" id="workToDate"/>
        </div>
    </fieldset>
    <fieldset>
        <legend>Computer Skils</legend>
        <div id="inner-fieldset3-width">
            <label>Programming Languages</label>
            <div id="programming-languages">
                <div id="prog-lang-1">
                    <input type="text" name="programmingLanguages[]" />
                    <select name="programmingLanguageLevels[]">
                        <option>Beginner</option>
                        <option>Programmer</option>
                        <option>Advanced</option>
                        <option>expert</option>
                        <option>Ninja</option>
                    </select>
                </div>
            </div>
        </div>
        <input type="button" value="Remove Language" id="remove-prog-lang" />
        <input type="button" value="Add Language" id="add-prog-lang" />
    </fieldset>
    <fieldset>
        <legend>Other skils</legend>
        <label>Languages</label><br />
        <div id="languages">
            <div id="lang-1">
                <input type="text" name="languages[]" />
                <select name="comprehension[]">
                    <option selected disabled>-Comprehension-</option>
                    <option>beginner</option>
                    <option>intermediate</option>
                    <option>advanced</option>
                </select>
                <select name="reading[]">
                    <option selected disabled>-Reading-</option>
                    <option>beginner</option>
                    <option>intermediate</option>
                    <option>advanced</option>
                </select>
                <select name="writing[]">
                    <option selected disabled>-Writing-</option>
                    <option>beginner</option>
                    <option>intermediate</option>
                    <option>advanced</option>
                </select>
            </div>
        </div>
        <input type="button" value="Remove Language" id="remove-lang" />
        <input type="button" value="Add Language" id="add-lang" />
        <label>Driver's license</label><br />
        <label for="driver-license-b">B</label>
        <input type="checkbox" id="driver-license-b" value="B" name="driverLicenses[]" />
        <label for="driver-license-a">A</label>
        <input type="checkbox" id="driver-license-a" value="A" name="driverLicenses[]" />
        <label for="driver-license-c">C</label>
        <input type="checkbox" id="driver-license-c" value="C" name="driverLicenses[]" />
    </fieldset>
    <input type="submit" value="Generate CV" name="submit" />
</form>
</body>
</html>