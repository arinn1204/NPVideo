using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace VideoDB.UnitTests
{
    [TestClass()]
    public class AddVideoTests : SqlDatabaseTestClass
    {

        public AddVideoTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldReturnExpectedSchema_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition expectedSchemaCondition2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVideoTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldReturnExpectedSchema_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddVideoInsertsIntoVideoTable_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddVideoInsertsIntoVideoTable_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddVideoInsertsIntoVideoTable_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testInitializeAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddGenreWhenNotExist_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotAddDuplicateGenres_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotAddDuplicateGenres_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddsRatingsIntoTable_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddsMultipleGenres_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddsMultipleRatingsWithDifferentSources_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition19;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddMultipleRatingsWithSameSource_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition20;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition21;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition22;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition23;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddPersonRoleWhenNotExist_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition24;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotAddDuplicateRoles_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition25;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LinksVideoWithAllGenresInJoiner_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition26;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition27;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition28;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition29;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition30;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition31;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DoesNotAddDuplicateRoles_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddPersonThatDoesntExist_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition32;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition33;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition34;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddSeveralPeopleWithOneExisting_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition38;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition35;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition36;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition37;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddSeveralPeopleWithOneExisting_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LinksPersonsWithRoles_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition39;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition40;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition41;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition42;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LinksPersonsWithRoles_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LinksPersonsWithVideo_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition43;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition44;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition45;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition46;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction LinksPersonsWithVideo_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CanInsertVideoUsingExistingStars_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition19;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition47;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition20;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition21;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition22;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition23;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition24;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition49;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition48;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition25;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition50;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition51;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition26;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction CanInsertVideoUsingExistingStars_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddExistingVideoAndUpdate_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition33;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition60;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction AddExistingVideoAndUpdate_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction InsertingDuplicateVideoDoesNotUpdate_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition34;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction InsertingDuplicateVideoDoesNotUpdate_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testCleanupAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfImdbIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition52;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfVideoTypeIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition53;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition54;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition55;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfTitleIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition56;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition57;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition58;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfPlotIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition61;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition62;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition63;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfReleaseDateIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition59;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition64;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition65;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition66;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition67;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition68;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition69;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition70;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition71;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition27;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition72;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition73;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition74;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition75;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition76;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition77;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition78;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition79;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldNotInsertMetadataIfItIsASeries_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition80;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition81;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition82;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition28;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition29;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition83;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition84;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition85;
            this.ShouldReturnExpectedSchemaData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddVideoInsertsIntoVideoTableData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddGenreWhenNotExistData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DoesNotAddDuplicateGenresData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddsRatingsIntoTableData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddsMultipleGenresData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddsMultipleRatingsWithDifferentSourcesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddMultipleRatingsWithSameSourceData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddPersonRoleWhenNotExistData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DoesNotAddDuplicateRolesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.LinksVideoWithAllGenresInJoinerData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddPersonThatDoesntExistData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddSeveralPeopleWithOneExistingData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.LinksPersonsWithRolesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.LinksPersonsWithVideoData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.CanInsertVideoUsingExistingStarsData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.AddExistingVideoAndUpdateData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.InsertingDuplicateVideoDoesNotUpdateData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfImdbIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfVideoTypeIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfTitleIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfPlotIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfReleaseDateIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldNotInsertMetadataIfItIsASeriesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowIfResolutionIsNullAndTypeIsMovieData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowIfCodecIsNullAndTypeIsMovieData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            ShouldReturnExpectedSchema_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            expectedSchemaCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            ShouldReturnExpectedSchema_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddVideoInsertsIntoVideoTable_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddVideoInsertsIntoVideoTable_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddVideoInsertsIntoVideoTable_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddGenreWhenNotExist_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            DoesNotAddDuplicateGenres_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            DoesNotAddDuplicateGenres_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddsRatingsIntoTable_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddsMultipleGenres_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddsMultipleRatingsWithDifferentSources_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition19 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddMultipleRatingsWithSameSource_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition20 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition21 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition22 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition23 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddPersonRoleWhenNotExist_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition24 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            DoesNotAddDuplicateRoles_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition25 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            LinksVideoWithAllGenresInJoiner_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition26 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition27 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition28 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition29 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition30 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition31 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            DoesNotAddDuplicateRoles_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddPersonThatDoesntExist_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition32 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition33 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition34 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddSeveralPeopleWithOneExisting_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition38 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition35 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition36 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition37 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            AddSeveralPeopleWithOneExisting_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            LinksPersonsWithRoles_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition39 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition40 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition41 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition42 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            LinksPersonsWithRoles_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            LinksPersonsWithVideo_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition43 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition44 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition45 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition46 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            LinksPersonsWithVideo_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CanInsertVideoUsingExistingStars_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition19 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition47 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition20 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition21 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition22 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition23 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition24 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition49 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition48 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition25 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition50 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition51 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition26 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            CanInsertVideoUsingExistingStars_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            AddExistingVideoAndUpdate_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition33 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition60 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            emptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            AddExistingVideoAndUpdate_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            InsertingDuplicateVideoDoesNotUpdate_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition34 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            notEmptyResultSetCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            InsertingDuplicateVideoDoesNotUpdate_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testCleanupAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldThrowErrorIfImdbIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition52 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfVideoTypeIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition53 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition54 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition55 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfTitleIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition56 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition57 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition58 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfPlotIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition61 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition62 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition63 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfReleaseDateIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition59 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition64 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition65 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition66 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition67 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition68 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition69 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition70 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition71 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition27 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition72 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition73 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition74 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition75 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition76 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition77 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition78 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition79 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldNotInsertMetadataIfItIsASeries_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition80 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition81 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition82 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition28 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition29 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition83 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition84 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition85 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // ShouldReturnExpectedSchema_TestAction
            // 
            ShouldReturnExpectedSchema_TestAction.Conditions.Add(expectedSchemaCondition2);
            resources.ApplyResources(ShouldReturnExpectedSchema_TestAction, "ShouldReturnExpectedSchema_TestAction");
            // 
            // expectedSchemaCondition2
            // 
            expectedSchemaCondition2.Enabled = true;
            expectedSchemaCondition2.Name = "expectedSchemaCondition2";
            resources.ApplyResources(expectedSchemaCondition2, "expectedSchemaCondition2");
            expectedSchemaCondition2.Verbose = false;
            // 
            // ShouldReturnExpectedSchema_PretestAction
            // 
            resources.ApplyResources(ShouldReturnExpectedSchema_PretestAction, "ShouldReturnExpectedSchema_PretestAction");
            // 
            // AddVideoInsertsIntoVideoTable_TestAction
            // 
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(rowCountCondition2);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition2);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition3);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition4);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition5);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition6);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition7);
            AddVideoInsertsIntoVideoTable_TestAction.Conditions.Add(scalarValueCondition8);
            resources.ApplyResources(AddVideoInsertsIntoVideoTable_TestAction, "AddVideoInsertsIntoVideoTable_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 2;
            rowCountCondition2.RowCount = 1;
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "tt1234";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 2;
            scalarValueCondition2.RowNumber = 1;
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 2;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "Video Title goes here";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 2;
            scalarValueCondition3.RowNumber = 1;
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 3;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "PG-13";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 2;
            scalarValueCondition4.RowNumber = 1;
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 4;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = "120.95";
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = false;
            scalarValueCondition5.ResultSet = 2;
            scalarValueCondition5.RowNumber = 1;
            // 
            // scalarValueCondition6
            // 
            scalarValueCondition6.ColumnNumber = 5;
            scalarValueCondition6.Enabled = true;
            scalarValueCondition6.ExpectedValue = "some plot here";
            scalarValueCondition6.Name = "scalarValueCondition6";
            scalarValueCondition6.NullExpected = false;
            scalarValueCondition6.ResultSet = 2;
            scalarValueCondition6.RowNumber = 1;
            // 
            // scalarValueCondition7
            // 
            scalarValueCondition7.ColumnNumber = 6;
            scalarValueCondition7.Enabled = true;
            scalarValueCondition7.ExpectedValue = "movie";
            scalarValueCondition7.Name = "scalarValueCondition7";
            scalarValueCondition7.NullExpected = false;
            scalarValueCondition7.ResultSet = 2;
            scalarValueCondition7.RowNumber = 1;
            // 
            // scalarValueCondition8
            // 
            scalarValueCondition8.ColumnNumber = 7;
            scalarValueCondition8.Enabled = true;
            scalarValueCondition8.ExpectedValue = "1993.12.04";
            scalarValueCondition8.Name = "scalarValueCondition8";
            scalarValueCondition8.NullExpected = false;
            scalarValueCondition8.ResultSet = 2;
            scalarValueCondition8.RowNumber = 1;
            // 
            // AddVideoInsertsIntoVideoTable_PretestAction
            // 
            resources.ApplyResources(AddVideoInsertsIntoVideoTable_PretestAction, "AddVideoInsertsIntoVideoTable_PretestAction");
            // 
            // AddVideoInsertsIntoVideoTable_PosttestAction
            // 
            resources.ApplyResources(AddVideoInsertsIntoVideoTable_PosttestAction, "AddVideoInsertsIntoVideoTable_PosttestAction");
            // 
            // testInitializeAction
            // 
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // AddGenreWhenNotExist_TestAction
            // 
            AddGenreWhenNotExist_TestAction.Conditions.Add(scalarValueCondition11);
            AddGenreWhenNotExist_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(AddGenreWhenNotExist_TestAction, "AddGenreWhenNotExist_TestAction");
            // 
            // scalarValueCondition11
            // 
            scalarValueCondition11.ColumnNumber = 1;
            scalarValueCondition11.Enabled = true;
            scalarValueCondition11.ExpectedValue = "Horror";
            scalarValueCondition11.Name = "scalarValueCondition11";
            scalarValueCondition11.NullExpected = false;
            scalarValueCondition11.ResultSet = 2;
            scalarValueCondition11.RowNumber = 1;
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 2;
            rowCountCondition1.RowCount = 1;
            // 
            // DoesNotAddDuplicateGenres_TestAction
            // 
            DoesNotAddDuplicateGenres_TestAction.Conditions.Add(rowCountCondition3);
            resources.ApplyResources(DoesNotAddDuplicateGenres_TestAction, "DoesNotAddDuplicateGenres_TestAction");
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 2;
            rowCountCondition3.RowCount = 1;
            // 
            // DoesNotAddDuplicateGenres_PretestAction
            // 
            resources.ApplyResources(DoesNotAddDuplicateGenres_PretestAction, "DoesNotAddDuplicateGenres_PretestAction");
            // 
            // AddsRatingsIntoTable_TestAction
            // 
            AddsRatingsIntoTable_TestAction.Conditions.Add(rowCountCondition4);
            AddsRatingsIntoTable_TestAction.Conditions.Add(scalarValueCondition12);
            AddsRatingsIntoTable_TestAction.Conditions.Add(scalarValueCondition13);
            resources.ApplyResources(AddsRatingsIntoTable_TestAction, "AddsRatingsIntoTable_TestAction");
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 2;
            rowCountCondition4.RowCount = 1;
            // 
            // scalarValueCondition12
            // 
            scalarValueCondition12.ColumnNumber = 1;
            scalarValueCondition12.Enabled = true;
            scalarValueCondition12.ExpectedValue = "Metacritic";
            scalarValueCondition12.Name = "scalarValueCondition12";
            scalarValueCondition12.NullExpected = false;
            scalarValueCondition12.ResultSet = 2;
            scalarValueCondition12.RowNumber = 1;
            // 
            // scalarValueCondition13
            // 
            scalarValueCondition13.ColumnNumber = 2;
            scalarValueCondition13.Enabled = true;
            scalarValueCondition13.ExpectedValue = "11.34";
            scalarValueCondition13.Name = "scalarValueCondition13";
            scalarValueCondition13.NullExpected = false;
            scalarValueCondition13.ResultSet = 2;
            scalarValueCondition13.RowNumber = 1;
            // 
            // AddsMultipleGenres_TestAction
            // 
            AddsMultipleGenres_TestAction.Conditions.Add(rowCountCondition5);
            AddsMultipleGenres_TestAction.Conditions.Add(scalarValueCondition14);
            AddsMultipleGenres_TestAction.Conditions.Add(scalarValueCondition15);
            resources.ApplyResources(AddsMultipleGenres_TestAction, "AddsMultipleGenres_TestAction");
            // 
            // rowCountCondition5
            // 
            rowCountCondition5.Enabled = true;
            rowCountCondition5.Name = "rowCountCondition5";
            rowCountCondition5.ResultSet = 2;
            rowCountCondition5.RowCount = 2;
            // 
            // scalarValueCondition14
            // 
            scalarValueCondition14.ColumnNumber = 1;
            scalarValueCondition14.Enabled = true;
            scalarValueCondition14.ExpectedValue = "Horror";
            scalarValueCondition14.Name = "scalarValueCondition14";
            scalarValueCondition14.NullExpected = false;
            scalarValueCondition14.ResultSet = 2;
            scalarValueCondition14.RowNumber = 2;
            // 
            // scalarValueCondition15
            // 
            scalarValueCondition15.ColumnNumber = 1;
            scalarValueCondition15.Enabled = true;
            scalarValueCondition15.ExpectedValue = "Comedy";
            scalarValueCondition15.Name = "scalarValueCondition15";
            scalarValueCondition15.NullExpected = false;
            scalarValueCondition15.ResultSet = 2;
            scalarValueCondition15.RowNumber = 1;
            // 
            // AddsMultipleRatingsWithDifferentSources_TestAction
            // 
            AddsMultipleRatingsWithDifferentSources_TestAction.Conditions.Add(rowCountCondition6);
            AddsMultipleRatingsWithDifferentSources_TestAction.Conditions.Add(scalarValueCondition16);
            AddsMultipleRatingsWithDifferentSources_TestAction.Conditions.Add(scalarValueCondition17);
            AddsMultipleRatingsWithDifferentSources_TestAction.Conditions.Add(scalarValueCondition18);
            AddsMultipleRatingsWithDifferentSources_TestAction.Conditions.Add(scalarValueCondition19);
            resources.ApplyResources(AddsMultipleRatingsWithDifferentSources_TestAction, "AddsMultipleRatingsWithDifferentSources_TestAction");
            // 
            // rowCountCondition6
            // 
            rowCountCondition6.Enabled = true;
            rowCountCondition6.Name = "rowCountCondition6";
            rowCountCondition6.ResultSet = 1;
            rowCountCondition6.RowCount = 1;
            // 
            // scalarValueCondition16
            // 
            scalarValueCondition16.ColumnNumber = 1;
            scalarValueCondition16.Enabled = true;
            scalarValueCondition16.ExpectedValue = "Metacritic";
            scalarValueCondition16.Name = "scalarValueCondition16";
            scalarValueCondition16.NullExpected = false;
            scalarValueCondition16.ResultSet = 2;
            scalarValueCondition16.RowNumber = 1;
            // 
            // scalarValueCondition17
            // 
            scalarValueCondition17.ColumnNumber = 2;
            scalarValueCondition17.Enabled = true;
            scalarValueCondition17.ExpectedValue = "11.34";
            scalarValueCondition17.Name = "scalarValueCondition17";
            scalarValueCondition17.NullExpected = false;
            scalarValueCondition17.ResultSet = 2;
            scalarValueCondition17.RowNumber = 1;
            // 
            // scalarValueCondition18
            // 
            scalarValueCondition18.ColumnNumber = 1;
            scalarValueCondition18.Enabled = true;
            scalarValueCondition18.ExpectedValue = "Rotten Tomatoes";
            scalarValueCondition18.Name = "scalarValueCondition18";
            scalarValueCondition18.NullExpected = false;
            scalarValueCondition18.ResultSet = 2;
            scalarValueCondition18.RowNumber = 2;
            // 
            // scalarValueCondition19
            // 
            scalarValueCondition19.ColumnNumber = 2;
            scalarValueCondition19.Enabled = true;
            scalarValueCondition19.ExpectedValue = "12.34";
            scalarValueCondition19.Name = "scalarValueCondition19";
            scalarValueCondition19.NullExpected = false;
            scalarValueCondition19.ResultSet = 2;
            scalarValueCondition19.RowNumber = 2;
            // 
            // AddMultipleRatingsWithSameSource_TestAction
            // 
            AddMultipleRatingsWithSameSource_TestAction.Conditions.Add(rowCountCondition7);
            AddMultipleRatingsWithSameSource_TestAction.Conditions.Add(scalarValueCondition20);
            AddMultipleRatingsWithSameSource_TestAction.Conditions.Add(scalarValueCondition21);
            AddMultipleRatingsWithSameSource_TestAction.Conditions.Add(scalarValueCondition22);
            AddMultipleRatingsWithSameSource_TestAction.Conditions.Add(scalarValueCondition23);
            resources.ApplyResources(AddMultipleRatingsWithSameSource_TestAction, "AddMultipleRatingsWithSameSource_TestAction");
            // 
            // rowCountCondition7
            // 
            rowCountCondition7.Enabled = true;
            rowCountCondition7.Name = "rowCountCondition7";
            rowCountCondition7.ResultSet = 2;
            rowCountCondition7.RowCount = 2;
            // 
            // scalarValueCondition20
            // 
            scalarValueCondition20.ColumnNumber = 1;
            scalarValueCondition20.Enabled = true;
            scalarValueCondition20.ExpectedValue = "Metacritic";
            scalarValueCondition20.Name = "scalarValueCondition20";
            scalarValueCondition20.NullExpected = false;
            scalarValueCondition20.ResultSet = 2;
            scalarValueCondition20.RowNumber = 1;
            // 
            // scalarValueCondition21
            // 
            scalarValueCondition21.ColumnNumber = 2;
            scalarValueCondition21.Enabled = true;
            scalarValueCondition21.ExpectedValue = "11.34";
            scalarValueCondition21.Name = "scalarValueCondition21";
            scalarValueCondition21.NullExpected = false;
            scalarValueCondition21.ResultSet = 2;
            scalarValueCondition21.RowNumber = 1;
            // 
            // scalarValueCondition22
            // 
            scalarValueCondition22.ColumnNumber = 1;
            scalarValueCondition22.Enabled = true;
            scalarValueCondition22.ExpectedValue = "Metacritic";
            scalarValueCondition22.Name = "scalarValueCondition22";
            scalarValueCondition22.NullExpected = false;
            scalarValueCondition22.ResultSet = 2;
            scalarValueCondition22.RowNumber = 1;
            // 
            // scalarValueCondition23
            // 
            scalarValueCondition23.ColumnNumber = 2;
            scalarValueCondition23.Enabled = true;
            scalarValueCondition23.ExpectedValue = "12.34";
            scalarValueCondition23.Name = "scalarValueCondition23";
            scalarValueCondition23.NullExpected = false;
            scalarValueCondition23.ResultSet = 2;
            scalarValueCondition23.RowNumber = 2;
            // 
            // AddPersonRoleWhenNotExist_TestAction
            // 
            AddPersonRoleWhenNotExist_TestAction.Conditions.Add(rowCountCondition8);
            AddPersonRoleWhenNotExist_TestAction.Conditions.Add(scalarValueCondition24);
            resources.ApplyResources(AddPersonRoleWhenNotExist_TestAction, "AddPersonRoleWhenNotExist_TestAction");
            // 
            // rowCountCondition8
            // 
            rowCountCondition8.Enabled = true;
            rowCountCondition8.Name = "rowCountCondition8";
            rowCountCondition8.ResultSet = 2;
            rowCountCondition8.RowCount = 1;
            // 
            // scalarValueCondition24
            // 
            scalarValueCondition24.ColumnNumber = 1;
            scalarValueCondition24.Enabled = true;
            scalarValueCondition24.ExpectedValue = "Director";
            scalarValueCondition24.Name = "scalarValueCondition24";
            scalarValueCondition24.NullExpected = false;
            scalarValueCondition24.ResultSet = 2;
            scalarValueCondition24.RowNumber = 1;
            // 
            // DoesNotAddDuplicateRoles_TestAction
            // 
            DoesNotAddDuplicateRoles_TestAction.Conditions.Add(rowCountCondition9);
            DoesNotAddDuplicateRoles_TestAction.Conditions.Add(scalarValueCondition25);
            resources.ApplyResources(DoesNotAddDuplicateRoles_TestAction, "DoesNotAddDuplicateRoles_TestAction");
            // 
            // rowCountCondition9
            // 
            rowCountCondition9.Enabled = true;
            rowCountCondition9.Name = "rowCountCondition9";
            rowCountCondition9.ResultSet = 2;
            rowCountCondition9.RowCount = 1;
            // 
            // scalarValueCondition25
            // 
            scalarValueCondition25.ColumnNumber = 1;
            scalarValueCondition25.Enabled = true;
            scalarValueCondition25.ExpectedValue = "Actor";
            scalarValueCondition25.Name = "scalarValueCondition25";
            scalarValueCondition25.NullExpected = false;
            scalarValueCondition25.ResultSet = 2;
            scalarValueCondition25.RowNumber = 1;
            // 
            // LinksVideoWithAllGenresInJoiner_TestAction
            // 
            LinksVideoWithAllGenresInJoiner_TestAction.Conditions.Add(rowCountCondition10);
            LinksVideoWithAllGenresInJoiner_TestAction.Conditions.Add(scalarValueCondition26);
            LinksVideoWithAllGenresInJoiner_TestAction.Conditions.Add(scalarValueCondition27);
            LinksVideoWithAllGenresInJoiner_TestAction.Conditions.Add(scalarValueCondition28);
            LinksVideoWithAllGenresInJoiner_TestAction.Conditions.Add(scalarValueCondition29);
            resources.ApplyResources(LinksVideoWithAllGenresInJoiner_TestAction, "LinksVideoWithAllGenresInJoiner_TestAction");
            // 
            // rowCountCondition10
            // 
            rowCountCondition10.Enabled = true;
            rowCountCondition10.Name = "rowCountCondition10";
            rowCountCondition10.ResultSet = 2;
            rowCountCondition10.RowCount = 2;
            // 
            // scalarValueCondition26
            // 
            scalarValueCondition26.ColumnNumber = 1;
            scalarValueCondition26.Enabled = true;
            scalarValueCondition26.ExpectedValue = "1";
            scalarValueCondition26.Name = "scalarValueCondition26";
            scalarValueCondition26.NullExpected = false;
            scalarValueCondition26.ResultSet = 2;
            scalarValueCondition26.RowNumber = 1;
            // 
            // scalarValueCondition27
            // 
            scalarValueCondition27.ColumnNumber = 2;
            scalarValueCondition27.Enabled = true;
            scalarValueCondition27.ExpectedValue = "1";
            scalarValueCondition27.Name = "scalarValueCondition27";
            scalarValueCondition27.NullExpected = false;
            scalarValueCondition27.ResultSet = 2;
            scalarValueCondition27.RowNumber = 1;
            // 
            // scalarValueCondition28
            // 
            scalarValueCondition28.ColumnNumber = 1;
            scalarValueCondition28.Enabled = true;
            scalarValueCondition28.ExpectedValue = "1";
            scalarValueCondition28.Name = "scalarValueCondition28";
            scalarValueCondition28.NullExpected = false;
            scalarValueCondition28.ResultSet = 2;
            scalarValueCondition28.RowNumber = 2;
            // 
            // scalarValueCondition29
            // 
            scalarValueCondition29.ColumnNumber = 2;
            scalarValueCondition29.Enabled = true;
            scalarValueCondition29.ExpectedValue = "2";
            scalarValueCondition29.Name = "scalarValueCondition29";
            scalarValueCondition29.NullExpected = false;
            scalarValueCondition29.ResultSet = 2;
            scalarValueCondition29.RowNumber = 2;
            // 
            // DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction
            // 
            DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction.Conditions.Add(rowCountCondition11);
            DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction.Conditions.Add(scalarValueCondition30);
            DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction.Conditions.Add(scalarValueCondition31);
            resources.ApplyResources(DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction, "DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction");
            // 
            // rowCountCondition11
            // 
            rowCountCondition11.Enabled = true;
            rowCountCondition11.Name = "rowCountCondition11";
            rowCountCondition11.ResultSet = 2;
            rowCountCondition11.RowCount = 1;
            // 
            // scalarValueCondition30
            // 
            scalarValueCondition30.ColumnNumber = 1;
            scalarValueCondition30.Enabled = true;
            scalarValueCondition30.ExpectedValue = "1";
            scalarValueCondition30.Name = "scalarValueCondition30";
            scalarValueCondition30.NullExpected = false;
            scalarValueCondition30.ResultSet = 2;
            scalarValueCondition30.RowNumber = 1;
            // 
            // scalarValueCondition31
            // 
            scalarValueCondition31.ColumnNumber = 2;
            scalarValueCondition31.Enabled = true;
            scalarValueCondition31.ExpectedValue = "2";
            scalarValueCondition31.Name = "scalarValueCondition31";
            scalarValueCondition31.NullExpected = false;
            scalarValueCondition31.ResultSet = 2;
            scalarValueCondition31.RowNumber = 1;
            // 
            // DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction
            // 
            resources.ApplyResources(DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction, "DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction");
            // 
            // DoesNotAddDuplicateRoles_PretestAction
            // 
            resources.ApplyResources(DoesNotAddDuplicateRoles_PretestAction, "DoesNotAddDuplicateRoles_PretestAction");
            // 
            // AddPersonThatDoesntExist_TestAction
            // 
            AddPersonThatDoesntExist_TestAction.Conditions.Add(rowCountCondition12);
            AddPersonThatDoesntExist_TestAction.Conditions.Add(scalarValueCondition1);
            AddPersonThatDoesntExist_TestAction.Conditions.Add(scalarValueCondition32);
            AddPersonThatDoesntExist_TestAction.Conditions.Add(scalarValueCondition33);
            AddPersonThatDoesntExist_TestAction.Conditions.Add(scalarValueCondition34);
            resources.ApplyResources(AddPersonThatDoesntExist_TestAction, "AddPersonThatDoesntExist_TestAction");
            // 
            // rowCountCondition12
            // 
            rowCountCondition12.Enabled = true;
            rowCountCondition12.Name = "rowCountCondition12";
            rowCountCondition12.ResultSet = 2;
            rowCountCondition12.RowCount = 1;
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "John";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 2;
            scalarValueCondition1.RowNumber = 1;
            // 
            // scalarValueCondition32
            // 
            scalarValueCondition32.ColumnNumber = 2;
            scalarValueCondition32.Enabled = true;
            scalarValueCondition32.ExpectedValue = "F";
            scalarValueCondition32.Name = "scalarValueCondition32";
            scalarValueCondition32.NullExpected = false;
            scalarValueCondition32.ResultSet = 2;
            scalarValueCondition32.RowNumber = 1;
            // 
            // scalarValueCondition33
            // 
            scalarValueCondition33.ColumnNumber = 3;
            scalarValueCondition33.Enabled = true;
            scalarValueCondition33.ExpectedValue = "Kennedy";
            scalarValueCondition33.Name = "scalarValueCondition33";
            scalarValueCondition33.NullExpected = false;
            scalarValueCondition33.ResultSet = 2;
            scalarValueCondition33.RowNumber = 1;
            // 
            // scalarValueCondition34
            // 
            scalarValueCondition34.ColumnNumber = 4;
            scalarValueCondition34.Enabled = true;
            scalarValueCondition34.ExpectedValue = "III";
            scalarValueCondition34.Name = "scalarValueCondition34";
            scalarValueCondition34.NullExpected = false;
            scalarValueCondition34.ResultSet = 2;
            scalarValueCondition34.RowNumber = 1;
            // 
            // AddSeveralPeopleWithOneExisting_TestAction
            // 
            AddSeveralPeopleWithOneExisting_TestAction.Conditions.Add(rowCountCondition13);
            AddSeveralPeopleWithOneExisting_TestAction.Conditions.Add(scalarValueCondition38);
            AddSeveralPeopleWithOneExisting_TestAction.Conditions.Add(scalarValueCondition35);
            AddSeveralPeopleWithOneExisting_TestAction.Conditions.Add(scalarValueCondition36);
            AddSeveralPeopleWithOneExisting_TestAction.Conditions.Add(scalarValueCondition37);
            resources.ApplyResources(AddSeveralPeopleWithOneExisting_TestAction, "AddSeveralPeopleWithOneExisting_TestAction");
            // 
            // rowCountCondition13
            // 
            rowCountCondition13.Enabled = true;
            rowCountCondition13.Name = "rowCountCondition13";
            rowCountCondition13.ResultSet = 2;
            rowCountCondition13.RowCount = 4;
            // 
            // scalarValueCondition38
            // 
            scalarValueCondition38.ColumnNumber = 1;
            scalarValueCondition38.Enabled = true;
            scalarValueCondition38.ExpectedValue = "Cher";
            scalarValueCondition38.Name = "scalarValueCondition38";
            scalarValueCondition38.NullExpected = false;
            scalarValueCondition38.ResultSet = 3;
            scalarValueCondition38.RowNumber = 1;
            // 
            // scalarValueCondition35
            // 
            scalarValueCondition35.ColumnNumber = 2;
            scalarValueCondition35.Enabled = true;
            scalarValueCondition35.ExpectedValue = null;
            scalarValueCondition35.Name = "scalarValueCondition35";
            scalarValueCondition35.NullExpected = true;
            scalarValueCondition35.ResultSet = 3;
            scalarValueCondition35.RowNumber = 1;
            // 
            // scalarValueCondition36
            // 
            scalarValueCondition36.ColumnNumber = 3;
            scalarValueCondition36.Enabled = true;
            scalarValueCondition36.ExpectedValue = null;
            scalarValueCondition36.Name = "scalarValueCondition36";
            scalarValueCondition36.NullExpected = true;
            scalarValueCondition36.ResultSet = 3;
            scalarValueCondition36.RowNumber = 1;
            // 
            // scalarValueCondition37
            // 
            scalarValueCondition37.ColumnNumber = 4;
            scalarValueCondition37.Enabled = true;
            scalarValueCondition37.ExpectedValue = null;
            scalarValueCondition37.Name = "scalarValueCondition37";
            scalarValueCondition37.NullExpected = true;
            scalarValueCondition37.ResultSet = 3;
            scalarValueCondition37.RowNumber = 1;
            // 
            // AddSeveralPeopleWithOneExisting_PretestAction
            // 
            resources.ApplyResources(AddSeveralPeopleWithOneExisting_PretestAction, "AddSeveralPeopleWithOneExisting_PretestAction");
            // 
            // LinksPersonsWithRoles_TestAction
            // 
            LinksPersonsWithRoles_TestAction.Conditions.Add(rowCountCondition14);
            LinksPersonsWithRoles_TestAction.Conditions.Add(scalarValueCondition39);
            LinksPersonsWithRoles_TestAction.Conditions.Add(scalarValueCondition40);
            LinksPersonsWithRoles_TestAction.Conditions.Add(scalarValueCondition41);
            LinksPersonsWithRoles_TestAction.Conditions.Add(scalarValueCondition42);
            LinksPersonsWithRoles_TestAction.Conditions.Add(rowCountCondition15);
            LinksPersonsWithRoles_TestAction.Conditions.Add(rowCountCondition16);
            resources.ApplyResources(LinksPersonsWithRoles_TestAction, "LinksPersonsWithRoles_TestAction");
            // 
            // rowCountCondition14
            // 
            rowCountCondition14.Enabled = true;
            rowCountCondition14.Name = "rowCountCondition14";
            rowCountCondition14.ResultSet = 2;
            rowCountCondition14.RowCount = 2;
            // 
            // scalarValueCondition39
            // 
            scalarValueCondition39.ColumnNumber = 1;
            scalarValueCondition39.Enabled = true;
            scalarValueCondition39.ExpectedValue = "1";
            scalarValueCondition39.Name = "scalarValueCondition39";
            scalarValueCondition39.NullExpected = false;
            scalarValueCondition39.ResultSet = 2;
            scalarValueCondition39.RowNumber = 1;
            // 
            // scalarValueCondition40
            // 
            scalarValueCondition40.ColumnNumber = 2;
            scalarValueCondition40.Enabled = true;
            scalarValueCondition40.ExpectedValue = "2";
            scalarValueCondition40.Name = "scalarValueCondition40";
            scalarValueCondition40.NullExpected = false;
            scalarValueCondition40.ResultSet = 2;
            scalarValueCondition40.RowNumber = 1;
            // 
            // scalarValueCondition41
            // 
            scalarValueCondition41.ColumnNumber = 1;
            scalarValueCondition41.Enabled = true;
            scalarValueCondition41.ExpectedValue = "2";
            scalarValueCondition41.Name = "scalarValueCondition41";
            scalarValueCondition41.NullExpected = false;
            scalarValueCondition41.ResultSet = 2;
            scalarValueCondition41.RowNumber = 2;
            // 
            // scalarValueCondition42
            // 
            scalarValueCondition42.ColumnNumber = 2;
            scalarValueCondition42.Enabled = true;
            scalarValueCondition42.ExpectedValue = "3";
            scalarValueCondition42.Name = "scalarValueCondition42";
            scalarValueCondition42.NullExpected = false;
            scalarValueCondition42.ResultSet = 2;
            scalarValueCondition42.RowNumber = 2;
            // 
            // rowCountCondition15
            // 
            rowCountCondition15.Enabled = true;
            rowCountCondition15.Name = "rowCountCondition15";
            rowCountCondition15.ResultSet = 3;
            rowCountCondition15.RowCount = 3;
            // 
            // rowCountCondition16
            // 
            rowCountCondition16.Enabled = true;
            rowCountCondition16.Name = "rowCountCondition16";
            rowCountCondition16.ResultSet = 4;
            rowCountCondition16.RowCount = 2;
            // 
            // LinksPersonsWithRoles_PretestAction
            // 
            resources.ApplyResources(LinksPersonsWithRoles_PretestAction, "LinksPersonsWithRoles_PretestAction");
            // 
            // LinksPersonsWithVideo_TestAction
            // 
            LinksPersonsWithVideo_TestAction.Conditions.Add(rowCountCondition17);
            LinksPersonsWithVideo_TestAction.Conditions.Add(scalarValueCondition43);
            LinksPersonsWithVideo_TestAction.Conditions.Add(scalarValueCondition44);
            LinksPersonsWithVideo_TestAction.Conditions.Add(scalarValueCondition45);
            LinksPersonsWithVideo_TestAction.Conditions.Add(scalarValueCondition46);
            resources.ApplyResources(LinksPersonsWithVideo_TestAction, "LinksPersonsWithVideo_TestAction");
            // 
            // rowCountCondition17
            // 
            rowCountCondition17.Enabled = true;
            rowCountCondition17.Name = "rowCountCondition17";
            rowCountCondition17.ResultSet = 2;
            rowCountCondition17.RowCount = 2;
            // 
            // scalarValueCondition43
            // 
            scalarValueCondition43.ColumnNumber = 1;
            scalarValueCondition43.Enabled = true;
            scalarValueCondition43.ExpectedValue = "1";
            scalarValueCondition43.Name = "scalarValueCondition43";
            scalarValueCondition43.NullExpected = false;
            scalarValueCondition43.ResultSet = 2;
            scalarValueCondition43.RowNumber = 1;
            // 
            // scalarValueCondition44
            // 
            scalarValueCondition44.ColumnNumber = 2;
            scalarValueCondition44.Enabled = true;
            scalarValueCondition44.ExpectedValue = "2";
            scalarValueCondition44.Name = "scalarValueCondition44";
            scalarValueCondition44.NullExpected = false;
            scalarValueCondition44.ResultSet = 2;
            scalarValueCondition44.RowNumber = 1;
            // 
            // scalarValueCondition45
            // 
            scalarValueCondition45.ColumnNumber = 2;
            scalarValueCondition45.Enabled = true;
            scalarValueCondition45.ExpectedValue = "2";
            scalarValueCondition45.Name = "scalarValueCondition45";
            scalarValueCondition45.NullExpected = false;
            scalarValueCondition45.ResultSet = 2;
            scalarValueCondition45.RowNumber = 2;
            // 
            // scalarValueCondition46
            // 
            scalarValueCondition46.ColumnNumber = 2;
            scalarValueCondition46.Enabled = true;
            scalarValueCondition46.ExpectedValue = "2";
            scalarValueCondition46.Name = "scalarValueCondition46";
            scalarValueCondition46.NullExpected = false;
            scalarValueCondition46.ResultSet = 2;
            scalarValueCondition46.RowNumber = 2;
            // 
            // LinksPersonsWithVideo_PretestAction
            // 
            resources.ApplyResources(LinksPersonsWithVideo_PretestAction, "LinksPersonsWithVideo_PretestAction");
            // 
            // CanInsertVideoUsingExistingStars_TestAction
            // 
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition18);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition19);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(scalarValueCondition47);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition20);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition21);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition22);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition23);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition24);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(scalarValueCondition49);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(scalarValueCondition48);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition25);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(scalarValueCondition50);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(scalarValueCondition51);
            CanInsertVideoUsingExistingStars_TestAction.Conditions.Add(rowCountCondition26);
            resources.ApplyResources(CanInsertVideoUsingExistingStars_TestAction, "CanInsertVideoUsingExistingStars_TestAction");
            // 
            // rowCountCondition18
            // 
            rowCountCondition18.Enabled = true;
            rowCountCondition18.Name = "rowCountCondition18";
            rowCountCondition18.ResultSet = 1;
            rowCountCondition18.RowCount = 1;
            // 
            // rowCountCondition19
            // 
            rowCountCondition19.Enabled = true;
            rowCountCondition19.Name = "rowCountCondition19";
            rowCountCondition19.ResultSet = 2;
            rowCountCondition19.RowCount = 2;
            // 
            // scalarValueCondition47
            // 
            scalarValueCondition47.ColumnNumber = 2;
            scalarValueCondition47.Enabled = true;
            scalarValueCondition47.ExpectedValue = "Horror";
            scalarValueCondition47.Name = "scalarValueCondition47";
            scalarValueCondition47.NullExpected = false;
            scalarValueCondition47.ResultSet = 2;
            scalarValueCondition47.RowNumber = 1;
            // 
            // rowCountCondition20
            // 
            rowCountCondition20.Enabled = true;
            rowCountCondition20.Name = "rowCountCondition20";
            rowCountCondition20.ResultSet = 3;
            rowCountCondition20.RowCount = 3;
            // 
            // rowCountCondition21
            // 
            rowCountCondition21.Enabled = true;
            rowCountCondition21.Name = "rowCountCondition21";
            rowCountCondition21.ResultSet = 4;
            rowCountCondition21.RowCount = 1;
            // 
            // rowCountCondition22
            // 
            rowCountCondition22.Enabled = true;
            rowCountCondition22.Name = "rowCountCondition22";
            rowCountCondition22.ResultSet = 5;
            rowCountCondition22.RowCount = 4;
            // 
            // rowCountCondition23
            // 
            rowCountCondition23.Enabled = true;
            rowCountCondition23.Name = "rowCountCondition23";
            rowCountCondition23.ResultSet = 6;
            rowCountCondition23.RowCount = 6;
            // 
            // rowCountCondition24
            // 
            rowCountCondition24.Enabled = true;
            rowCountCondition24.Name = "rowCountCondition24";
            rowCountCondition24.ResultSet = 7;
            rowCountCondition24.RowCount = 4;
            // 
            // scalarValueCondition49
            // 
            scalarValueCondition49.ColumnNumber = 1;
            scalarValueCondition49.Enabled = true;
            scalarValueCondition49.ExpectedValue = "2";
            scalarValueCondition49.Name = "scalarValueCondition49";
            scalarValueCondition49.NullExpected = false;
            scalarValueCondition49.ResultSet = 7;
            scalarValueCondition49.RowNumber = 2;
            // 
            // scalarValueCondition48
            // 
            scalarValueCondition48.ColumnNumber = 1;
            scalarValueCondition48.Enabled = true;
            scalarValueCondition48.ExpectedValue = "2";
            scalarValueCondition48.Name = "scalarValueCondition48";
            scalarValueCondition48.NullExpected = false;
            scalarValueCondition48.ResultSet = 7;
            scalarValueCondition48.RowNumber = 3;
            // 
            // rowCountCondition25
            // 
            rowCountCondition25.Enabled = true;
            rowCountCondition25.Name = "rowCountCondition25";
            rowCountCondition25.ResultSet = 8;
            rowCountCondition25.RowCount = 3;
            // 
            // scalarValueCondition50
            // 
            scalarValueCondition50.ColumnNumber = 1;
            scalarValueCondition50.Enabled = true;
            scalarValueCondition50.ExpectedValue = "1";
            scalarValueCondition50.Name = "scalarValueCondition50";
            scalarValueCondition50.NullExpected = false;
            scalarValueCondition50.ResultSet = 8;
            scalarValueCondition50.RowNumber = 1;
            // 
            // scalarValueCondition51
            // 
            scalarValueCondition51.ColumnNumber = 1;
            scalarValueCondition51.Enabled = true;
            scalarValueCondition51.ExpectedValue = "1";
            scalarValueCondition51.Name = "scalarValueCondition51";
            scalarValueCondition51.NullExpected = false;
            scalarValueCondition51.ResultSet = 8;
            scalarValueCondition51.RowNumber = 2;
            // 
            // rowCountCondition26
            // 
            rowCountCondition26.Enabled = true;
            rowCountCondition26.Name = "rowCountCondition26";
            rowCountCondition26.ResultSet = 9;
            rowCountCondition26.RowCount = 4;
            // 
            // CanInsertVideoUsingExistingStars_PretestAction
            // 
            resources.ApplyResources(CanInsertVideoUsingExistingStars_PretestAction, "CanInsertVideoUsingExistingStars_PretestAction");
            // 
            // AddExistingVideoAndUpdate_TestAction
            // 
            AddExistingVideoAndUpdate_TestAction.Conditions.Add(notEmptyResultSetCondition1);
            AddExistingVideoAndUpdate_TestAction.Conditions.Add(rowCountCondition33);
            AddExistingVideoAndUpdate_TestAction.Conditions.Add(scalarValueCondition60);
            AddExistingVideoAndUpdate_TestAction.Conditions.Add(emptyResultSetCondition1);
            resources.ApplyResources(AddExistingVideoAndUpdate_TestAction, "AddExistingVideoAndUpdate_TestAction");
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 1;
            // 
            // rowCountCondition33
            // 
            rowCountCondition33.Enabled = true;
            rowCountCondition33.Name = "rowCountCondition33";
            rowCountCondition33.ResultSet = 2;
            rowCountCondition33.RowCount = 1;
            // 
            // scalarValueCondition60
            // 
            scalarValueCondition60.ColumnNumber = 2;
            scalarValueCondition60.Enabled = true;
            scalarValueCondition60.ExpectedValue = "some extended plot here with grammar changes";
            scalarValueCondition60.Name = "scalarValueCondition60";
            scalarValueCondition60.NullExpected = false;
            scalarValueCondition60.ResultSet = 2;
            scalarValueCondition60.RowNumber = 1;
            // 
            // emptyResultSetCondition1
            // 
            emptyResultSetCondition1.Enabled = true;
            emptyResultSetCondition1.Name = "emptyResultSetCondition1";
            emptyResultSetCondition1.ResultSet = 3;
            // 
            // AddExistingVideoAndUpdate_PretestAction
            // 
            resources.ApplyResources(AddExistingVideoAndUpdate_PretestAction, "AddExistingVideoAndUpdate_PretestAction");
            // 
            // InsertingDuplicateVideoDoesNotUpdate_TestAction
            // 
            InsertingDuplicateVideoDoesNotUpdate_TestAction.Conditions.Add(rowCountCondition34);
            InsertingDuplicateVideoDoesNotUpdate_TestAction.Conditions.Add(notEmptyResultSetCondition2);
            resources.ApplyResources(InsertingDuplicateVideoDoesNotUpdate_TestAction, "InsertingDuplicateVideoDoesNotUpdate_TestAction");
            // 
            // rowCountCondition34
            // 
            rowCountCondition34.Enabled = true;
            rowCountCondition34.Name = "rowCountCondition34";
            rowCountCondition34.ResultSet = 2;
            rowCountCondition34.RowCount = 1;
            // 
            // notEmptyResultSetCondition2
            // 
            notEmptyResultSetCondition2.Enabled = true;
            notEmptyResultSetCondition2.Name = "notEmptyResultSetCondition2";
            notEmptyResultSetCondition2.ResultSet = 3;
            // 
            // InsertingDuplicateVideoDoesNotUpdate_PretestAction
            // 
            resources.ApplyResources(InsertingDuplicateVideoDoesNotUpdate_PretestAction, "InsertingDuplicateVideoDoesNotUpdate_PretestAction");
            // 
            // testCleanupAction
            // 
            resources.ApplyResources(testCleanupAction, "testCleanupAction");
            // 
            // ShouldThrowErrorIfImdbIsNull_TestAction
            // 
            ShouldThrowErrorIfImdbIsNull_TestAction.Conditions.Add(scalarValueCondition9);
            ShouldThrowErrorIfImdbIsNull_TestAction.Conditions.Add(scalarValueCondition10);
            ShouldThrowErrorIfImdbIsNull_TestAction.Conditions.Add(scalarValueCondition52);
            resources.ApplyResources(ShouldThrowErrorIfImdbIsNull_TestAction, "ShouldThrowErrorIfImdbIsNull_TestAction");
            // 
            // scalarValueCondition9
            // 
            scalarValueCondition9.ColumnNumber = 1;
            scalarValueCondition9.Enabled = true;
            scalarValueCondition9.ExpectedValue = "@imdb_id is a required parameter.";
            scalarValueCondition9.Name = "scalarValueCondition9";
            scalarValueCondition9.NullExpected = false;
            scalarValueCondition9.ResultSet = 1;
            scalarValueCondition9.RowNumber = 1;
            // 
            // scalarValueCondition10
            // 
            scalarValueCondition10.ColumnNumber = 2;
            scalarValueCondition10.Enabled = true;
            scalarValueCondition10.ExpectedValue = "16";
            scalarValueCondition10.Name = "scalarValueCondition10";
            scalarValueCondition10.NullExpected = false;
            scalarValueCondition10.ResultSet = 1;
            scalarValueCondition10.RowNumber = 1;
            // 
            // scalarValueCondition52
            // 
            scalarValueCondition52.ColumnNumber = 3;
            scalarValueCondition52.Enabled = true;
            scalarValueCondition52.ExpectedValue = "1";
            scalarValueCondition52.Name = "scalarValueCondition52";
            scalarValueCondition52.NullExpected = false;
            scalarValueCondition52.ResultSet = 1;
            scalarValueCondition52.RowNumber = 1;
            // 
            // ShouldThrowErrorIfVideoTypeIsNull_TestAction
            // 
            ShouldThrowErrorIfVideoTypeIsNull_TestAction.Conditions.Add(scalarValueCondition53);
            ShouldThrowErrorIfVideoTypeIsNull_TestAction.Conditions.Add(scalarValueCondition54);
            ShouldThrowErrorIfVideoTypeIsNull_TestAction.Conditions.Add(scalarValueCondition55);
            resources.ApplyResources(ShouldThrowErrorIfVideoTypeIsNull_TestAction, "ShouldThrowErrorIfVideoTypeIsNull_TestAction");
            // 
            // scalarValueCondition53
            // 
            scalarValueCondition53.ColumnNumber = 1;
            scalarValueCondition53.Enabled = true;
            scalarValueCondition53.ExpectedValue = "@video_type is a required parameter.";
            scalarValueCondition53.Name = "scalarValueCondition53";
            scalarValueCondition53.NullExpected = false;
            scalarValueCondition53.ResultSet = 1;
            scalarValueCondition53.RowNumber = 1;
            // 
            // scalarValueCondition54
            // 
            scalarValueCondition54.ColumnNumber = 2;
            scalarValueCondition54.Enabled = true;
            scalarValueCondition54.ExpectedValue = "16";
            scalarValueCondition54.Name = "scalarValueCondition54";
            scalarValueCondition54.NullExpected = false;
            scalarValueCondition54.ResultSet = 1;
            scalarValueCondition54.RowNumber = 1;
            // 
            // scalarValueCondition55
            // 
            scalarValueCondition55.ColumnNumber = 3;
            scalarValueCondition55.Enabled = true;
            scalarValueCondition55.ExpectedValue = "1";
            scalarValueCondition55.Name = "scalarValueCondition55";
            scalarValueCondition55.NullExpected = false;
            scalarValueCondition55.ResultSet = 1;
            scalarValueCondition55.RowNumber = 1;
            // 
            // ShouldThrowErrorIfTitleIsNull_TestAction
            // 
            ShouldThrowErrorIfTitleIsNull_TestAction.Conditions.Add(scalarValueCondition56);
            ShouldThrowErrorIfTitleIsNull_TestAction.Conditions.Add(scalarValueCondition57);
            ShouldThrowErrorIfTitleIsNull_TestAction.Conditions.Add(scalarValueCondition58);
            resources.ApplyResources(ShouldThrowErrorIfTitleIsNull_TestAction, "ShouldThrowErrorIfTitleIsNull_TestAction");
            // 
            // scalarValueCondition56
            // 
            scalarValueCondition56.ColumnNumber = 1;
            scalarValueCondition56.Enabled = true;
            scalarValueCondition56.ExpectedValue = "@title is a required parameter.";
            scalarValueCondition56.Name = "scalarValueCondition56";
            scalarValueCondition56.NullExpected = false;
            scalarValueCondition56.ResultSet = 1;
            scalarValueCondition56.RowNumber = 1;
            // 
            // scalarValueCondition57
            // 
            scalarValueCondition57.ColumnNumber = 2;
            scalarValueCondition57.Enabled = true;
            scalarValueCondition57.ExpectedValue = "16";
            scalarValueCondition57.Name = "scalarValueCondition57";
            scalarValueCondition57.NullExpected = false;
            scalarValueCondition57.ResultSet = 1;
            scalarValueCondition57.RowNumber = 1;
            // 
            // scalarValueCondition58
            // 
            scalarValueCondition58.ColumnNumber = 3;
            scalarValueCondition58.Enabled = true;
            scalarValueCondition58.ExpectedValue = "1";
            scalarValueCondition58.Name = "scalarValueCondition58";
            scalarValueCondition58.NullExpected = false;
            scalarValueCondition58.ResultSet = 1;
            scalarValueCondition58.RowNumber = 1;
            // 
            // ShouldThrowErrorIfPlotIsNull_TestAction
            // 
            ShouldThrowErrorIfPlotIsNull_TestAction.Conditions.Add(scalarValueCondition61);
            ShouldThrowErrorIfPlotIsNull_TestAction.Conditions.Add(scalarValueCondition62);
            ShouldThrowErrorIfPlotIsNull_TestAction.Conditions.Add(scalarValueCondition63);
            resources.ApplyResources(ShouldThrowErrorIfPlotIsNull_TestAction, "ShouldThrowErrorIfPlotIsNull_TestAction");
            // 
            // scalarValueCondition61
            // 
            scalarValueCondition61.ColumnNumber = 1;
            scalarValueCondition61.Enabled = true;
            scalarValueCondition61.ExpectedValue = "@plot is a required parameter.";
            scalarValueCondition61.Name = "scalarValueCondition61";
            scalarValueCondition61.NullExpected = false;
            scalarValueCondition61.ResultSet = 1;
            scalarValueCondition61.RowNumber = 1;
            // 
            // scalarValueCondition62
            // 
            scalarValueCondition62.ColumnNumber = 2;
            scalarValueCondition62.Enabled = true;
            scalarValueCondition62.ExpectedValue = "16";
            scalarValueCondition62.Name = "scalarValueCondition62";
            scalarValueCondition62.NullExpected = false;
            scalarValueCondition62.ResultSet = 1;
            scalarValueCondition62.RowNumber = 1;
            // 
            // scalarValueCondition63
            // 
            scalarValueCondition63.ColumnNumber = 3;
            scalarValueCondition63.Enabled = true;
            scalarValueCondition63.ExpectedValue = "1";
            scalarValueCondition63.Name = "scalarValueCondition63";
            scalarValueCondition63.NullExpected = false;
            scalarValueCondition63.ResultSet = 1;
            scalarValueCondition63.RowNumber = 1;
            // 
            // ShouldThrowErrorIfReleaseDateIsNull_TestAction
            // 
            ShouldThrowErrorIfReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition59);
            ShouldThrowErrorIfReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition64);
            ShouldThrowErrorIfReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition65);
            resources.ApplyResources(ShouldThrowErrorIfReleaseDateIsNull_TestAction, "ShouldThrowErrorIfReleaseDateIsNull_TestAction");
            // 
            // scalarValueCondition59
            // 
            scalarValueCondition59.ColumnNumber = 1;
            scalarValueCondition59.Enabled = true;
            scalarValueCondition59.ExpectedValue = "@release_date is a required parameter.";
            scalarValueCondition59.Name = "scalarValueCondition59";
            scalarValueCondition59.NullExpected = false;
            scalarValueCondition59.ResultSet = 1;
            scalarValueCondition59.RowNumber = 1;
            // 
            // scalarValueCondition64
            // 
            scalarValueCondition64.ColumnNumber = 2;
            scalarValueCondition64.Enabled = true;
            scalarValueCondition64.ExpectedValue = "16";
            scalarValueCondition64.Name = "scalarValueCondition64";
            scalarValueCondition64.NullExpected = false;
            scalarValueCondition64.ResultSet = 1;
            scalarValueCondition64.RowNumber = 1;
            // 
            // scalarValueCondition65
            // 
            scalarValueCondition65.ColumnNumber = 3;
            scalarValueCondition65.Enabled = true;
            scalarValueCondition65.ExpectedValue = "1";
            scalarValueCondition65.Name = "scalarValueCondition65";
            scalarValueCondition65.NullExpected = false;
            scalarValueCondition65.ResultSet = 1;
            scalarValueCondition65.RowNumber = 1;
            // 
            // ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction
            // 
            ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition66);
            ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition67);
            ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition68);
            resources.ApplyResources(ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction, "ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction");
            // 
            // scalarValueCondition66
            // 
            scalarValueCondition66.ColumnNumber = 1;
            scalarValueCondition66.Enabled = true;
            scalarValueCondition66.ExpectedValue = "@mpaa_rating is a required parameter for video_type = movie.";
            scalarValueCondition66.Name = "scalarValueCondition66";
            scalarValueCondition66.NullExpected = false;
            scalarValueCondition66.ResultSet = 1;
            scalarValueCondition66.RowNumber = 1;
            // 
            // scalarValueCondition67
            // 
            scalarValueCondition67.ColumnNumber = 2;
            scalarValueCondition67.Enabled = true;
            scalarValueCondition67.ExpectedValue = "16";
            scalarValueCondition67.Name = "scalarValueCondition67";
            scalarValueCondition67.NullExpected = false;
            scalarValueCondition67.ResultSet = 1;
            scalarValueCondition67.RowNumber = 1;
            // 
            // scalarValueCondition68
            // 
            scalarValueCondition68.ColumnNumber = 3;
            scalarValueCondition68.Enabled = true;
            scalarValueCondition68.ExpectedValue = "1";
            scalarValueCondition68.Name = "scalarValueCondition68";
            scalarValueCondition68.NullExpected = false;
            scalarValueCondition68.ResultSet = 1;
            scalarValueCondition68.RowNumber = 1;
            // 
            // ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction
            // 
            ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition69);
            ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition70);
            ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition71);
            resources.ApplyResources(ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction, "ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction");
            // 
            // scalarValueCondition69
            // 
            scalarValueCondition69.ColumnNumber = 1;
            scalarValueCondition69.Enabled = true;
            scalarValueCondition69.ExpectedValue = "@runtime is a required parameter for video_type = movie.";
            scalarValueCondition69.Name = "scalarValueCondition69";
            scalarValueCondition69.NullExpected = false;
            scalarValueCondition69.ResultSet = 1;
            scalarValueCondition69.RowNumber = 1;
            // 
            // scalarValueCondition70
            // 
            scalarValueCondition70.ColumnNumber = 2;
            scalarValueCondition70.Enabled = true;
            scalarValueCondition70.ExpectedValue = "16";
            scalarValueCondition70.Name = "scalarValueCondition70";
            scalarValueCondition70.NullExpected = false;
            scalarValueCondition70.ResultSet = 1;
            scalarValueCondition70.RowNumber = 1;
            // 
            // scalarValueCondition71
            // 
            scalarValueCondition71.ColumnNumber = 3;
            scalarValueCondition71.Enabled = true;
            scalarValueCondition71.ExpectedValue = "1";
            scalarValueCondition71.Name = "scalarValueCondition71";
            scalarValueCondition71.NullExpected = false;
            scalarValueCondition71.ResultSet = 1;
            scalarValueCondition71.RowNumber = 1;
            // 
            // ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction
            // 
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction.Conditions.Add(rowCountCondition27);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction.Conditions.Add(scalarValueCondition72);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction.Conditions.Add(scalarValueCondition73);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction.Conditions.Add(scalarValueCondition74);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction.Conditions.Add(scalarValueCondition75);
            resources.ApplyResources(ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction, "ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction");
            // 
            // rowCountCondition27
            // 
            rowCountCondition27.Enabled = true;
            rowCountCondition27.Name = "rowCountCondition27";
            rowCountCondition27.ResultSet = 2;
            rowCountCondition27.RowCount = 1;
            // 
            // scalarValueCondition72
            // 
            scalarValueCondition72.ColumnNumber = 1;
            scalarValueCondition72.Enabled = true;
            scalarValueCondition72.ExpectedValue = "1";
            scalarValueCondition72.Name = "scalarValueCondition72";
            scalarValueCondition72.NullExpected = false;
            scalarValueCondition72.ResultSet = 1;
            scalarValueCondition72.RowNumber = 1;
            // 
            // scalarValueCondition73
            // 
            scalarValueCondition73.ColumnNumber = 2;
            scalarValueCondition73.Enabled = true;
            scalarValueCondition73.ExpectedValue = "1080p";
            scalarValueCondition73.Name = "scalarValueCondition73";
            scalarValueCondition73.NullExpected = false;
            scalarValueCondition73.ResultSet = 2;
            scalarValueCondition73.RowNumber = 1;
            // 
            // scalarValueCondition74
            // 
            scalarValueCondition74.ColumnNumber = 3;
            scalarValueCondition74.Enabled = true;
            scalarValueCondition74.ExpectedValue = "x265";
            scalarValueCondition74.Name = "scalarValueCondition74";
            scalarValueCondition74.NullExpected = false;
            scalarValueCondition74.ResultSet = 2;
            scalarValueCondition74.RowNumber = 1;
            // 
            // scalarValueCondition75
            // 
            scalarValueCondition75.ColumnNumber = 4;
            scalarValueCondition75.Enabled = true;
            scalarValueCondition75.ExpectedValue = "Directors Cut";
            scalarValueCondition75.Name = "scalarValueCondition75";
            scalarValueCondition75.NullExpected = false;
            scalarValueCondition75.ResultSet = 2;
            scalarValueCondition75.RowNumber = 1;
            // 
            // ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction
            // 
            ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition76);
            ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition77);
            ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition78);
            ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition79);
            resources.ApplyResources(ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction, "ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction");
            // 
            // scalarValueCondition76
            // 
            scalarValueCondition76.ColumnNumber = 1;
            scalarValueCondition76.Enabled = true;
            scalarValueCondition76.ExpectedValue = "1";
            scalarValueCondition76.Name = "scalarValueCondition76";
            scalarValueCondition76.NullExpected = false;
            scalarValueCondition76.ResultSet = 2;
            scalarValueCondition76.RowNumber = 1;
            // 
            // scalarValueCondition77
            // 
            scalarValueCondition77.ColumnNumber = 2;
            scalarValueCondition77.Enabled = true;
            scalarValueCondition77.ExpectedValue = "1080p";
            scalarValueCondition77.Name = "scalarValueCondition77";
            scalarValueCondition77.NullExpected = false;
            scalarValueCondition77.ResultSet = 2;
            scalarValueCondition77.RowNumber = 1;
            // 
            // scalarValueCondition78
            // 
            scalarValueCondition78.ColumnNumber = 3;
            scalarValueCondition78.Enabled = true;
            scalarValueCondition78.ExpectedValue = "x265";
            scalarValueCondition78.Name = "scalarValueCondition78";
            scalarValueCondition78.NullExpected = false;
            scalarValueCondition78.ResultSet = 2;
            scalarValueCondition78.RowNumber = 1;
            // 
            // scalarValueCondition79
            // 
            scalarValueCondition79.ColumnNumber = 4;
            scalarValueCondition79.Enabled = true;
            scalarValueCondition79.ExpectedValue = null;
            scalarValueCondition79.Name = "scalarValueCondition79";
            scalarValueCondition79.NullExpected = true;
            scalarValueCondition79.ResultSet = 2;
            scalarValueCondition79.RowNumber = 1;
            // 
            // ShouldNotInsertMetadataIfItIsASeries_TestAction
            // 
            ShouldNotInsertMetadataIfItIsASeries_TestAction.Conditions.Add(emptyResultSetCondition2);
            resources.ApplyResources(ShouldNotInsertMetadataIfItIsASeries_TestAction, "ShouldNotInsertMetadataIfItIsASeries_TestAction");
            // 
            // emptyResultSetCondition2
            // 
            emptyResultSetCondition2.Enabled = true;
            emptyResultSetCondition2.Name = "emptyResultSetCondition2";
            emptyResultSetCondition2.ResultSet = 2;
            // 
            // ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction
            // 
            ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition80);
            ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition81);
            ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition82);
            ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction.Conditions.Add(rowCountCondition28);
            resources.ApplyResources(ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction, "ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction");
            // 
            // scalarValueCondition80
            // 
            scalarValueCondition80.ColumnNumber = 1;
            scalarValueCondition80.Enabled = true;
            scalarValueCondition80.ExpectedValue = "@resolution is a required parameter for video_type = movie.";
            scalarValueCondition80.Name = "scalarValueCondition80";
            scalarValueCondition80.NullExpected = false;
            scalarValueCondition80.ResultSet = 1;
            scalarValueCondition80.RowNumber = 1;
            // 
            // scalarValueCondition81
            // 
            scalarValueCondition81.ColumnNumber = 2;
            scalarValueCondition81.Enabled = true;
            scalarValueCondition81.ExpectedValue = "16";
            scalarValueCondition81.Name = "scalarValueCondition81";
            scalarValueCondition81.NullExpected = false;
            scalarValueCondition81.ResultSet = 1;
            scalarValueCondition81.RowNumber = 1;
            // 
            // scalarValueCondition82
            // 
            scalarValueCondition82.ColumnNumber = 3;
            scalarValueCondition82.Enabled = true;
            scalarValueCondition82.ExpectedValue = "1";
            scalarValueCondition82.Name = "scalarValueCondition82";
            scalarValueCondition82.NullExpected = false;
            scalarValueCondition82.ResultSet = 1;
            scalarValueCondition82.RowNumber = 1;
            // 
            // rowCountCondition28
            // 
            rowCountCondition28.Enabled = true;
            rowCountCondition28.Name = "rowCountCondition28";
            rowCountCondition28.ResultSet = 1;
            rowCountCondition28.RowCount = 1;
            // 
            // ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction
            // 
            ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction.Conditions.Add(rowCountCondition29);
            ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition83);
            ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition84);
            ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction.Conditions.Add(scalarValueCondition85);
            resources.ApplyResources(ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction, "ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction");
            // 
            // rowCountCondition29
            // 
            rowCountCondition29.Enabled = true;
            rowCountCondition29.Name = "rowCountCondition29";
            rowCountCondition29.ResultSet = 1;
            rowCountCondition29.RowCount = 1;
            // 
            // scalarValueCondition83
            // 
            scalarValueCondition83.ColumnNumber = 1;
            scalarValueCondition83.Enabled = true;
            scalarValueCondition83.ExpectedValue = "@codec is a required parameter for video_type = movie.";
            scalarValueCondition83.Name = "scalarValueCondition83";
            scalarValueCondition83.NullExpected = false;
            scalarValueCondition83.ResultSet = 1;
            scalarValueCondition83.RowNumber = 1;
            // 
            // scalarValueCondition84
            // 
            scalarValueCondition84.ColumnNumber = 2;
            scalarValueCondition84.Enabled = true;
            scalarValueCondition84.ExpectedValue = "16";
            scalarValueCondition84.Name = "scalarValueCondition84";
            scalarValueCondition84.NullExpected = false;
            scalarValueCondition84.ResultSet = 1;
            scalarValueCondition84.RowNumber = 1;
            // 
            // scalarValueCondition85
            // 
            scalarValueCondition85.ColumnNumber = 3;
            scalarValueCondition85.Enabled = true;
            scalarValueCondition85.ExpectedValue = "1";
            scalarValueCondition85.Name = "scalarValueCondition85";
            scalarValueCondition85.NullExpected = false;
            scalarValueCondition85.ResultSet = 1;
            scalarValueCondition85.RowNumber = 1;
            // 
            // ShouldReturnExpectedSchemaData
            // 
            this.ShouldReturnExpectedSchemaData.PosttestAction = null;
            this.ShouldReturnExpectedSchemaData.PretestAction = ShouldReturnExpectedSchema_PretestAction;
            this.ShouldReturnExpectedSchemaData.TestAction = ShouldReturnExpectedSchema_TestAction;
            // 
            // AddVideoInsertsIntoVideoTableData
            // 
            this.AddVideoInsertsIntoVideoTableData.PosttestAction = AddVideoInsertsIntoVideoTable_PosttestAction;
            this.AddVideoInsertsIntoVideoTableData.PretestAction = AddVideoInsertsIntoVideoTable_PretestAction;
            this.AddVideoInsertsIntoVideoTableData.TestAction = AddVideoInsertsIntoVideoTable_TestAction;
            // 
            // AddGenreWhenNotExistData
            // 
            this.AddGenreWhenNotExistData.PosttestAction = null;
            this.AddGenreWhenNotExistData.PretestAction = null;
            this.AddGenreWhenNotExistData.TestAction = AddGenreWhenNotExist_TestAction;
            // 
            // DoesNotAddDuplicateGenresData
            // 
            this.DoesNotAddDuplicateGenresData.PosttestAction = null;
            this.DoesNotAddDuplicateGenresData.PretestAction = DoesNotAddDuplicateGenres_PretestAction;
            this.DoesNotAddDuplicateGenresData.TestAction = DoesNotAddDuplicateGenres_TestAction;
            // 
            // AddsRatingsIntoTableData
            // 
            this.AddsRatingsIntoTableData.PosttestAction = null;
            this.AddsRatingsIntoTableData.PretestAction = null;
            this.AddsRatingsIntoTableData.TestAction = AddsRatingsIntoTable_TestAction;
            // 
            // AddsMultipleGenresData
            // 
            this.AddsMultipleGenresData.PosttestAction = null;
            this.AddsMultipleGenresData.PretestAction = null;
            this.AddsMultipleGenresData.TestAction = AddsMultipleGenres_TestAction;
            // 
            // AddsMultipleRatingsWithDifferentSourcesData
            // 
            this.AddsMultipleRatingsWithDifferentSourcesData.PosttestAction = null;
            this.AddsMultipleRatingsWithDifferentSourcesData.PretestAction = null;
            this.AddsMultipleRatingsWithDifferentSourcesData.TestAction = AddsMultipleRatingsWithDifferentSources_TestAction;
            // 
            // AddMultipleRatingsWithSameSourceData
            // 
            this.AddMultipleRatingsWithSameSourceData.PosttestAction = null;
            this.AddMultipleRatingsWithSameSourceData.PretestAction = null;
            this.AddMultipleRatingsWithSameSourceData.TestAction = AddMultipleRatingsWithSameSource_TestAction;
            // 
            // AddPersonRoleWhenNotExistData
            // 
            this.AddPersonRoleWhenNotExistData.PosttestAction = null;
            this.AddPersonRoleWhenNotExistData.PretestAction = null;
            this.AddPersonRoleWhenNotExistData.TestAction = AddPersonRoleWhenNotExist_TestAction;
            // 
            // DoesNotAddDuplicateRolesData
            // 
            this.DoesNotAddDuplicateRolesData.PosttestAction = null;
            this.DoesNotAddDuplicateRolesData.PretestAction = DoesNotAddDuplicateRoles_PretestAction;
            this.DoesNotAddDuplicateRolesData.TestAction = DoesNotAddDuplicateRoles_TestAction;
            // 
            // LinksVideoWithAllGenresInJoinerData
            // 
            this.LinksVideoWithAllGenresInJoinerData.PosttestAction = null;
            this.LinksVideoWithAllGenresInJoinerData.PretestAction = null;
            this.LinksVideoWithAllGenresInJoinerData.TestAction = LinksVideoWithAllGenresInJoiner_TestAction;
            // 
            // DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData
            // 
            this.DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData.PosttestAction = null;
            this.DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData.PretestAction = DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_PretestAction;
            this.DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData.TestAction = DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo_TestAction;
            // 
            // AddPersonThatDoesntExistData
            // 
            this.AddPersonThatDoesntExistData.PosttestAction = null;
            this.AddPersonThatDoesntExistData.PretestAction = null;
            this.AddPersonThatDoesntExistData.TestAction = AddPersonThatDoesntExist_TestAction;
            // 
            // AddSeveralPeopleWithOneExistingData
            // 
            this.AddSeveralPeopleWithOneExistingData.PosttestAction = null;
            this.AddSeveralPeopleWithOneExistingData.PretestAction = AddSeveralPeopleWithOneExisting_PretestAction;
            this.AddSeveralPeopleWithOneExistingData.TestAction = AddSeveralPeopleWithOneExisting_TestAction;
            // 
            // LinksPersonsWithRolesData
            // 
            this.LinksPersonsWithRolesData.PosttestAction = null;
            this.LinksPersonsWithRolesData.PretestAction = LinksPersonsWithRoles_PretestAction;
            this.LinksPersonsWithRolesData.TestAction = LinksPersonsWithRoles_TestAction;
            // 
            // LinksPersonsWithVideoData
            // 
            this.LinksPersonsWithVideoData.PosttestAction = null;
            this.LinksPersonsWithVideoData.PretestAction = LinksPersonsWithVideo_PretestAction;
            this.LinksPersonsWithVideoData.TestAction = LinksPersonsWithVideo_TestAction;
            // 
            // CanInsertVideoUsingExistingStarsData
            // 
            this.CanInsertVideoUsingExistingStarsData.PosttestAction = null;
            this.CanInsertVideoUsingExistingStarsData.PretestAction = CanInsertVideoUsingExistingStars_PretestAction;
            this.CanInsertVideoUsingExistingStarsData.TestAction = CanInsertVideoUsingExistingStars_TestAction;
            // 
            // AddExistingVideoAndUpdateData
            // 
            this.AddExistingVideoAndUpdateData.PosttestAction = null;
            this.AddExistingVideoAndUpdateData.PretestAction = AddExistingVideoAndUpdate_PretestAction;
            this.AddExistingVideoAndUpdateData.TestAction = AddExistingVideoAndUpdate_TestAction;
            // 
            // InsertingDuplicateVideoDoesNotUpdateData
            // 
            this.InsertingDuplicateVideoDoesNotUpdateData.PosttestAction = null;
            this.InsertingDuplicateVideoDoesNotUpdateData.PretestAction = InsertingDuplicateVideoDoesNotUpdate_PretestAction;
            this.InsertingDuplicateVideoDoesNotUpdateData.TestAction = InsertingDuplicateVideoDoesNotUpdate_TestAction;
            // 
            // ShouldThrowErrorIfImdbIsNullData
            // 
            this.ShouldThrowErrorIfImdbIsNullData.PosttestAction = null;
            this.ShouldThrowErrorIfImdbIsNullData.PretestAction = null;
            this.ShouldThrowErrorIfImdbIsNullData.TestAction = ShouldThrowErrorIfImdbIsNull_TestAction;
            // 
            // ShouldThrowErrorIfVideoTypeIsNullData
            // 
            this.ShouldThrowErrorIfVideoTypeIsNullData.PosttestAction = null;
            this.ShouldThrowErrorIfVideoTypeIsNullData.PretestAction = null;
            this.ShouldThrowErrorIfVideoTypeIsNullData.TestAction = ShouldThrowErrorIfVideoTypeIsNull_TestAction;
            // 
            // ShouldThrowErrorIfTitleIsNullData
            // 
            this.ShouldThrowErrorIfTitleIsNullData.PosttestAction = null;
            this.ShouldThrowErrorIfTitleIsNullData.PretestAction = null;
            this.ShouldThrowErrorIfTitleIsNullData.TestAction = ShouldThrowErrorIfTitleIsNull_TestAction;
            // 
            // ShouldThrowErrorIfPlotIsNullData
            // 
            this.ShouldThrowErrorIfPlotIsNullData.PosttestAction = null;
            this.ShouldThrowErrorIfPlotIsNullData.PretestAction = null;
            this.ShouldThrowErrorIfPlotIsNullData.TestAction = ShouldThrowErrorIfPlotIsNull_TestAction;
            // 
            // ShouldThrowErrorIfReleaseDateIsNullData
            // 
            this.ShouldThrowErrorIfReleaseDateIsNullData.PosttestAction = null;
            this.ShouldThrowErrorIfReleaseDateIsNullData.PretestAction = null;
            this.ShouldThrowErrorIfReleaseDateIsNullData.TestAction = ShouldThrowErrorIfReleaseDateIsNull_TestAction;
            // 
            // ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData
            // 
            this.ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData.PosttestAction = null;
            this.ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData.PretestAction = null;
            this.ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData.TestAction = ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie_TestAction;
            // 
            // ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData
            // 
            this.ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData.PosttestAction = null;
            this.ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData.PretestAction = null;
            this.ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData.TestAction = ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie_TestAction;
            // 
            // ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData
            // 
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData.PosttestAction = null;
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData.PretestAction = null;
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData.TestAction = ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable_TestAction;
            // 
            // ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData
            // 
            this.ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData.PosttestAction = null;
            this.ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData.PretestAction = null;
            this.ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData.TestAction = ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata_TestAction;
            // 
            // ShouldNotInsertMetadataIfItIsASeriesData
            // 
            this.ShouldNotInsertMetadataIfItIsASeriesData.PosttestAction = null;
            this.ShouldNotInsertMetadataIfItIsASeriesData.PretestAction = null;
            this.ShouldNotInsertMetadataIfItIsASeriesData.TestAction = ShouldNotInsertMetadataIfItIsASeries_TestAction;
            // 
            // ShouldThrowIfResolutionIsNullAndTypeIsMovieData
            // 
            this.ShouldThrowIfResolutionIsNullAndTypeIsMovieData.PosttestAction = null;
            this.ShouldThrowIfResolutionIsNullAndTypeIsMovieData.PretestAction = null;
            this.ShouldThrowIfResolutionIsNullAndTypeIsMovieData.TestAction = ShouldThrowIfResolutionIsNullAndTypeIsMovie_TestAction;
            // 
            // ShouldThrowIfCodecIsNullAndTypeIsMovieData
            // 
            this.ShouldThrowIfCodecIsNullAndTypeIsMovieData.PosttestAction = null;
            this.ShouldThrowIfCodecIsNullAndTypeIsMovieData.PretestAction = null;
            this.ShouldThrowIfCodecIsNullAndTypeIsMovieData.TestAction = ShouldThrowIfCodecIsNullAndTypeIsMovie_TestAction;
            // 
            // AddVideoTests
            // 
            this.TestCleanupAction = testCleanupAction;
            this.TestInitializeAction = testInitializeAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion
        [TestMethod()]
        public void ShouldReturnExpectedSchema()
        {
            SqlDatabaseTestActions testActions = this.ShouldReturnExpectedSchemaData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddVideoInsertsIntoVideoTable()
        {
            SqlDatabaseTestActions testActions = this.AddVideoInsertsIntoVideoTableData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddGenreWhenNotExist()
        {
            SqlDatabaseTestActions testActions = this.AddGenreWhenNotExistData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DoesNotAddDuplicateGenres()
        {
            SqlDatabaseTestActions testActions = this.DoesNotAddDuplicateGenresData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddsRatingsIntoTable()
        {
            SqlDatabaseTestActions testActions = this.AddsRatingsIntoTableData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddsMultipleGenres()
        {
            SqlDatabaseTestActions testActions = this.AddsMultipleGenresData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddsMultipleRatingsWithDifferentSources()
        {
            SqlDatabaseTestActions testActions = this.AddsMultipleRatingsWithDifferentSourcesData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddMultipleRatingsWithSameSource()
        {
            SqlDatabaseTestActions testActions = this.AddMultipleRatingsWithSameSourceData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddPersonRoleWhenNotExist()
        {
            SqlDatabaseTestActions testActions = this.AddPersonRoleWhenNotExistData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DoesNotAddDuplicateRoles()
        {
            SqlDatabaseTestActions testActions = this.DoesNotAddDuplicateRolesData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void LinksVideoWithAllGenresInJoiner()
        {
            SqlDatabaseTestActions testActions = this.LinksVideoWithAllGenresInJoinerData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideo()
        {
            SqlDatabaseTestActions testActions = this.DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddPersonThatDoesntExist()
        {
            SqlDatabaseTestActions testActions = this.AddPersonThatDoesntExistData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddSeveralPeopleWithOneExisting()
        {
            SqlDatabaseTestActions testActions = this.AddSeveralPeopleWithOneExistingData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void LinksPersonsWithRoles()
        {
            SqlDatabaseTestActions testActions = this.LinksPersonsWithRolesData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void LinksPersonsWithVideo()
        {
            SqlDatabaseTestActions testActions = this.LinksPersonsWithVideoData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void CanInsertVideoUsingExistingStars()
        {
            SqlDatabaseTestActions testActions = this.CanInsertVideoUsingExistingStarsData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void AddExistingVideoAndUpdate()
        {
            SqlDatabaseTestActions testActions = this.AddExistingVideoAndUpdateData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void InsertingDuplicateVideoDoesNotUpdate()
        {
            SqlDatabaseTestActions testActions = this.InsertingDuplicateVideoDoesNotUpdateData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfImdbIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfImdbIsNullData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfVideoTypeIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfVideoTypeIsNullData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfTitleIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfTitleIsNullData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfPlotIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfPlotIsNullData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfReleaseDateIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfReleaseDateIsNullData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovie()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovie()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTable()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadata()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldNotInsertMetadataIfItIsASeries()
        {
            SqlDatabaseTestActions testActions = this.ShouldNotInsertMetadataIfItIsASeriesData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowIfResolutionIsNullAndTypeIsMovie()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowIfResolutionIsNullAndTypeIsMovieData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void ShouldThrowIfCodecIsNullAndTypeIsMovie()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowIfCodecIsNullAndTypeIsMovieData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }


























        private SqlDatabaseTestActions ShouldReturnExpectedSchemaData;
        private SqlDatabaseTestActions AddVideoInsertsIntoVideoTableData;
        private SqlDatabaseTestActions AddGenreWhenNotExistData;
        private SqlDatabaseTestActions DoesNotAddDuplicateGenresData;
        private SqlDatabaseTestActions AddsRatingsIntoTableData;
        private SqlDatabaseTestActions AddsMultipleGenresData;
        private SqlDatabaseTestActions AddsMultipleRatingsWithDifferentSourcesData;
        private SqlDatabaseTestActions AddMultipleRatingsWithSameSourceData;
        private SqlDatabaseTestActions AddPersonRoleWhenNotExistData;
        private SqlDatabaseTestActions DoesNotAddDuplicateRolesData;
        private SqlDatabaseTestActions LinksVideoWithAllGenresInJoinerData;
        private SqlDatabaseTestActions DoesNotLinkGenresAlreadyExistingButNotAssociatedWithVideoData;
        private SqlDatabaseTestActions AddPersonThatDoesntExistData;
        private SqlDatabaseTestActions AddSeveralPeopleWithOneExistingData;
        private SqlDatabaseTestActions LinksPersonsWithRolesData;
        private SqlDatabaseTestActions LinksPersonsWithVideoData;
        private SqlDatabaseTestActions CanInsertVideoUsingExistingStarsData;
        private SqlDatabaseTestActions AddExistingVideoAndUpdateData;
        private SqlDatabaseTestActions InsertingDuplicateVideoDoesNotUpdateData;
        private SqlDatabaseTestActions ShouldThrowErrorIfImdbIsNullData;
        private SqlDatabaseTestActions ShouldThrowErrorIfVideoTypeIsNullData;
        private SqlDatabaseTestActions ShouldThrowErrorIfTitleIsNullData;
        private SqlDatabaseTestActions ShouldThrowErrorIfPlotIsNullData;
        private SqlDatabaseTestActions ShouldThrowErrorIfReleaseDateIsNullData;
        private SqlDatabaseTestActions ShouldThrowErrorIfMpaaRatingIsNullAndTypeIsMovieData;
        private SqlDatabaseTestActions ShouldThrowErrorIfRuntimeIsNullAndTypeIsMovieData;
        private SqlDatabaseTestActions ShouldInsertCodecAndResolutionAndExtendedIntoMetadataTableData;
        private SqlDatabaseTestActions ShouldInsertCodecAndREsolutionAndNullExtendedIntoMetadataData;
        private SqlDatabaseTestActions ShouldNotInsertMetadataIfItIsASeriesData;
        private SqlDatabaseTestActions ShouldThrowIfResolutionIsNullAndTypeIsMovieData;
        private SqlDatabaseTestActions ShouldThrowIfCodecIsNullAndTypeIsMovieData;
    }
}
