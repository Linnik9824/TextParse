CREATE PROCEDURE [dbo].[UpdateParseInfo]
  @CurrentFile int,
  @CurrentFileName Varchar,
  @CountMatches  int

AS
  update ParseInfo 
  set CurrentFile=@CurrentFile, CurrentFileName=@CurrentFileName, CountMatches = @CountMatches where Id = 0;
return
