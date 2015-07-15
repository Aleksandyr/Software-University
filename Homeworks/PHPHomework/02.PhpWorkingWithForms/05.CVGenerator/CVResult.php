<?php
session_start();
if(!$_SESSION){
    die;
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <h1>Cv</h1>
    <table border="1">
        <thead>
            <tr>
                <th colspan="2">Personal Information</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>First Name</td>
                <td><?= $_SESSION['fName'] ?></td>
            </tr>
            <tr>
                <td>Last nAME</td>
                <td><?= $_SESSION['lName'] ?></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><?= $_SESSION['email'] ?></td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td><?= $_SESSION['phoneNumber'] ?></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td><?= $_SESSION['gender'] ?></td>
            </tr>
            <tr>
                <td>Birth Date</td>
                <td><?= $_SESSION['birthDate']; ?></td>
            </tr>
        </tbody>
    </table>
    <table border="1">
        <thead>
            <tr>
                <th colspan="2">Last Work Position</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Company Name</td>
                <td><?= $_SESSION['companyName'] ?></td>
            </tr>
            <tr>
                <td>From</td>
                <td><?= $_SESSION['workFromDate'] ?></td>
            </tr>
            <tr>
                <td>To</td>
                <td><?= $_SESSION['workToDate'] ?></td>
            </tr>
        </tbody>
    </table>
    <table border="1">
        <thead>
            <tr>
                <th colspan="4">Computer Skilss</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Programming languages</td>
                <td>
                    <table border="1">
                        <thead>
                            <tr>
                                <th>Language</th>
                                <th>Skill Level</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php
                            foreach($_SESSION["programmingLanguages"] as $id => $language){
                                echo "<tr><td>$language</td><td>{$_SESSION["programmingLanguageLevels"][$id]}</td></tr>";
                            }
                            ?>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <table border="1">
        <thead>
            <tr>
                <th colspan="3">Other Skills</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Languages</td>
                <td>
                    <table border="1">
                        <thead>
                            <tr>
                                <th>Language</th>
                                <th>Comprehension</th>
                                <th>Reading</th>
                                <th>Writing</th>
                            </tr>
                        </thead>
                        <tbody>
                        <?php
                        foreach ($_SESSION["languages"] as $id => $language) {
                            echo "<tr><td>$language</td><td>{$_SESSION["comprehension"][$id]}</td><td>{$_SESSION["reading"][$id]}</td><td>{$_SESSION["writing"][$id]}</td></tr>";
                        }
                        ?>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Driver's license</td>
                <td><?php echo implode(", ", $_SESSION["driverLicenses"]) ?></td>
            </tr>
        </tbody>
    </table>
</body>
</html>