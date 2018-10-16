CREATE TABLE [dbo].[ParseInfo]
(
  [Id] INT NOT NULL PRIMARY KEY, 
    [CurrentFile] INT NULL, 
    [CurrentFileName] VARCHAR(50) NULL, 
    [CountMatches] INT NULL
)
