ALTER TABLE Users
ADD GroupId INT NOT NULL,
FOREIGN KEY(GroupId) REFERENCES Groups(Id)
