using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvoDB.UnitTests
{
    [TestClass()]
    public class AddTvEpisodeTests : SqlDatabaseTestClass
    {

        public AddTvEpisodeTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testInitializeAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTvEpisodeTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldCreateSeriesInVideo_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldReturnExpectedSchema_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition expectedSchemaCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithDifferentResolution_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithDifferentResolution_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithDifferentCodec_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithDifferentCodec_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithExtended_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeWithExtended_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldUpdateEpisodeIfDataChanges_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldUpdateEpisodeIfDataChanges_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertRatingsOfTvEpisode_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldLinkEpisodesWithGenres_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldLinkEpisodesWithGenres_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldLinkPersonsWithIndividualEpisodes_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldLinkPersonsWithIndividualEpisodes_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testCleanupAction;
            this.ShouldCreateSeriesInVideoData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldCreateEntryInTvEpisodeWhenNotExistData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldReturnExpectedSchemaData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertNewEpisodeWithDifferentResolutionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertNewEpisodeWithDifferentCodecData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertNewEpisodeWithExtendedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldUpdateEpisodeIfDataChangesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertRatingsOfTvEpisodeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldLinkEpisodesWithGenresData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldLinkPersonsWithIndividualEpisodesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldCreateSeriesInVideo_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldReturnExpectedSchema_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            expectedSchemaCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            ShouldInsertNewEpisodeWithDifferentResolution_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertNewEpisodeWithDifferentResolution_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldInsertNewEpisodeWithDifferentCodec_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertNewEpisodeWithDifferentCodec_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldInsertNewEpisodeWithExtended_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertNewEpisodeWithExtended_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldUpdateEpisodeIfDataChanges_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            ShouldUpdateEpisodeIfDataChanges_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldInsertRatingsOfTvEpisode_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldLinkEpisodesWithGenres_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldLinkEpisodesWithGenres_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldLinkPersonsWithIndividualEpisodes_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldLinkPersonsWithIndividualEpisodes_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testCleanupAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // testInitializeAction
            // 
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // ShouldCreateSeriesInVideo_TestAction
            // 
            ShouldCreateSeriesInVideo_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(ShouldCreateSeriesInVideo_TestAction, "ShouldCreateSeriesInVideo_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 3;
            rowCountCondition1.RowCount = 1;
            // 
            // ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction
            // 
            ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction, "ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 3;
            rowCountCondition2.RowCount = 1;
            // 
            // ShouldReturnExpectedSchema_TestAction
            // 
            ShouldReturnExpectedSchema_TestAction.Conditions.Add(expectedSchemaCondition1);
            resources.ApplyResources(ShouldReturnExpectedSchema_TestAction, "ShouldReturnExpectedSchema_TestAction");
            // 
            // expectedSchemaCondition1
            // 
            expectedSchemaCondition1.Enabled = true;
            expectedSchemaCondition1.Name = "expectedSchemaCondition1";
            resources.ApplyResources(expectedSchemaCondition1, "expectedSchemaCondition1");
            expectedSchemaCondition1.Verbose = false;
            // 
            // ShouldInsertNewEpisodeWithDifferentResolution_TestAction
            // 
            ShouldInsertNewEpisodeWithDifferentResolution_TestAction.Conditions.Add(rowCountCondition3);
            ShouldInsertNewEpisodeWithDifferentResolution_TestAction.Conditions.Add(scalarValueCondition1);
            ShouldInsertNewEpisodeWithDifferentResolution_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(ShouldInsertNewEpisodeWithDifferentResolution_TestAction, "ShouldInsertNewEpisodeWithDifferentResolution_TestAction");
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 3;
            rowCountCondition3.RowCount = 2;
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "1080p";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 3;
            scalarValueCondition1.RowNumber = 1;
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "10801p";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 3;
            scalarValueCondition2.RowNumber = 2;
            // 
            // ShouldInsertNewEpisodeWithDifferentResolution_PretestAction
            // 
            resources.ApplyResources(ShouldInsertNewEpisodeWithDifferentResolution_PretestAction, "ShouldInsertNewEpisodeWithDifferentResolution_PretestAction");
            // 
            // ShouldInsertNewEpisodeWithDifferentCodec_TestAction
            // 
            ShouldInsertNewEpisodeWithDifferentCodec_TestAction.Conditions.Add(rowCountCondition4);
            ShouldInsertNewEpisodeWithDifferentCodec_TestAction.Conditions.Add(scalarValueCondition3);
            ShouldInsertNewEpisodeWithDifferentCodec_TestAction.Conditions.Add(scalarValueCondition4);
            resources.ApplyResources(ShouldInsertNewEpisodeWithDifferentCodec_TestAction, "ShouldInsertNewEpisodeWithDifferentCodec_TestAction");
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 3;
            rowCountCondition4.RowCount = 2;
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "x265";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 3;
            scalarValueCondition3.RowNumber = 1;
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "x264";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 3;
            scalarValueCondition4.RowNumber = 2;
            // 
            // ShouldInsertNewEpisodeWithDifferentCodec_PretestAction
            // 
            resources.ApplyResources(ShouldInsertNewEpisodeWithDifferentCodec_PretestAction, "ShouldInsertNewEpisodeWithDifferentCodec_PretestAction");
            // 
            // ShouldInsertNewEpisodeWithExtended_TestAction
            // 
            ShouldInsertNewEpisodeWithExtended_TestAction.Conditions.Add(rowCountCondition5);
            ShouldInsertNewEpisodeWithExtended_TestAction.Conditions.Add(scalarValueCondition5);
            ShouldInsertNewEpisodeWithExtended_TestAction.Conditions.Add(scalarValueCondition6);
            resources.ApplyResources(ShouldInsertNewEpisodeWithExtended_TestAction, "ShouldInsertNewEpisodeWithExtended_TestAction");
            // 
            // rowCountCondition5
            // 
            rowCountCondition5.Enabled = true;
            rowCountCondition5.Name = "rowCountCondition5";
            rowCountCondition5.ResultSet = 3;
            rowCountCondition5.RowCount = 2;
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 1;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = null;
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = true;
            scalarValueCondition5.ResultSet = 3;
            scalarValueCondition5.RowNumber = 1;
            // 
            // scalarValueCondition6
            // 
            scalarValueCondition6.ColumnNumber = 1;
            scalarValueCondition6.Enabled = true;
            scalarValueCondition6.ExpectedValue = "REPACK";
            scalarValueCondition6.Name = "scalarValueCondition6";
            scalarValueCondition6.NullExpected = false;
            scalarValueCondition6.ResultSet = 3;
            scalarValueCondition6.RowNumber = 2;
            // 
            // ShouldInsertNewEpisodeWithExtended_PretestAction
            // 
            resources.ApplyResources(ShouldInsertNewEpisodeWithExtended_PretestAction, "ShouldInsertNewEpisodeWithExtended_PretestAction");
            // 
            // ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction
            // 
            ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction.Conditions.Add(emptyResultSetCondition1);
            resources.ApplyResources(ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction, "ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction");
            // 
            // emptyResultSetCondition1
            // 
            emptyResultSetCondition1.Enabled = true;
            emptyResultSetCondition1.Name = "emptyResultSetCondition1";
            emptyResultSetCondition1.ResultSet = 3;
            // 
            // ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction
            // 
            resources.ApplyResources(ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction, "ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction");
            // 
            // ShouldUpdateEpisodeIfDataChanges_TestAction
            // 
            ShouldUpdateEpisodeIfDataChanges_TestAction.Conditions.Add(rowCountCondition6);
            ShouldUpdateEpisodeIfDataChanges_TestAction.Conditions.Add(notEmptyResultSetCondition1);
            resources.ApplyResources(ShouldUpdateEpisodeIfDataChanges_TestAction, "ShouldUpdateEpisodeIfDataChanges_TestAction");
            // 
            // rowCountCondition6
            // 
            rowCountCondition6.Enabled = true;
            rowCountCondition6.Name = "rowCountCondition6";
            rowCountCondition6.ResultSet = 3;
            rowCountCondition6.RowCount = 1;
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 4;
            // 
            // ShouldUpdateEpisodeIfDataChanges_PretestAction
            // 
            resources.ApplyResources(ShouldUpdateEpisodeIfDataChanges_PretestAction, "ShouldUpdateEpisodeIfDataChanges_PretestAction");
            // 
            // ShouldInsertRatingsOfTvEpisode_TestAction
            // 
            ShouldInsertRatingsOfTvEpisode_TestAction.Conditions.Add(rowCountCondition7);
            ShouldInsertRatingsOfTvEpisode_TestAction.Conditions.Add(scalarValueCondition7);
            ShouldInsertRatingsOfTvEpisode_TestAction.Conditions.Add(scalarValueCondition8);
            ShouldInsertRatingsOfTvEpisode_TestAction.Conditions.Add(scalarValueCondition9);
            ShouldInsertRatingsOfTvEpisode_TestAction.Conditions.Add(scalarValueCondition10);
            resources.ApplyResources(ShouldInsertRatingsOfTvEpisode_TestAction, "ShouldInsertRatingsOfTvEpisode_TestAction");
            // 
            // rowCountCondition7
            // 
            rowCountCondition7.Enabled = true;
            rowCountCondition7.Name = "rowCountCondition7";
            rowCountCondition7.ResultSet = 3;
            rowCountCondition7.RowCount = 2;
            // 
            // scalarValueCondition7
            // 
            scalarValueCondition7.ColumnNumber = 1;
            scalarValueCondition7.Enabled = true;
            scalarValueCondition7.ExpectedValue = "1";
            scalarValueCondition7.Name = "scalarValueCondition7";
            scalarValueCondition7.NullExpected = false;
            scalarValueCondition7.ResultSet = 3;
            scalarValueCondition7.RowNumber = 1;
            // 
            // scalarValueCondition8
            // 
            scalarValueCondition8.ColumnNumber = 2;
            scalarValueCondition8.Enabled = true;
            scalarValueCondition8.ExpectedValue = null;
            scalarValueCondition8.Name = "scalarValueCondition8";
            scalarValueCondition8.NullExpected = true;
            scalarValueCondition8.ResultSet = 3;
            scalarValueCondition8.RowNumber = 1;
            // 
            // scalarValueCondition9
            // 
            scalarValueCondition9.ColumnNumber = 1;
            scalarValueCondition9.Enabled = true;
            scalarValueCondition9.ExpectedValue = "1";
            scalarValueCondition9.Name = "scalarValueCondition9";
            scalarValueCondition9.NullExpected = false;
            scalarValueCondition9.ResultSet = 3;
            scalarValueCondition9.RowNumber = 2;
            // 
            // scalarValueCondition10
            // 
            scalarValueCondition10.ColumnNumber = 2;
            scalarValueCondition10.Enabled = true;
            scalarValueCondition10.ExpectedValue = "1";
            scalarValueCondition10.Name = "scalarValueCondition10";
            scalarValueCondition10.NullExpected = false;
            scalarValueCondition10.ResultSet = 3;
            scalarValueCondition10.RowNumber = 2;
            // 
            // ShouldLinkEpisodesWithGenres_TestAction
            // 
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(rowCountCondition8);
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(rowCountCondition9);
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(scalarValueCondition11);
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(scalarValueCondition12);
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(scalarValueCondition13);
            ShouldLinkEpisodesWithGenres_TestAction.Conditions.Add(scalarValueCondition14);
            resources.ApplyResources(ShouldLinkEpisodesWithGenres_TestAction, "ShouldLinkEpisodesWithGenres_TestAction");
            // 
            // rowCountCondition8
            // 
            rowCountCondition8.Enabled = true;
            rowCountCondition8.Name = "rowCountCondition8";
            rowCountCondition8.ResultSet = 3;
            rowCountCondition8.RowCount = 3;
            // 
            // rowCountCondition9
            // 
            rowCountCondition9.Enabled = true;
            rowCountCondition9.Name = "rowCountCondition9";
            rowCountCondition9.ResultSet = 4;
            rowCountCondition9.RowCount = 1;
            // 
            // scalarValueCondition11
            // 
            scalarValueCondition11.ColumnNumber = 1;
            scalarValueCondition11.Enabled = true;
            scalarValueCondition11.ExpectedValue = "1";
            scalarValueCondition11.Name = "scalarValueCondition11";
            scalarValueCondition11.NullExpected = false;
            scalarValueCondition11.ResultSet = 3;
            scalarValueCondition11.RowNumber = 1;
            // 
            // scalarValueCondition12
            // 
            scalarValueCondition12.ColumnNumber = 1;
            scalarValueCondition12.Enabled = true;
            scalarValueCondition12.ExpectedValue = "3";
            scalarValueCondition12.Name = "scalarValueCondition12";
            scalarValueCondition12.NullExpected = false;
            scalarValueCondition12.ResultSet = 3;
            scalarValueCondition12.RowNumber = 2;
            // 
            // scalarValueCondition13
            // 
            scalarValueCondition13.ColumnNumber = 1;
            scalarValueCondition13.Enabled = true;
            scalarValueCondition13.ExpectedValue = "4";
            scalarValueCondition13.Name = "scalarValueCondition13";
            scalarValueCondition13.NullExpected = false;
            scalarValueCondition13.ResultSet = 3;
            scalarValueCondition13.RowNumber = 3;
            // 
            // scalarValueCondition14
            // 
            scalarValueCondition14.ColumnNumber = 1;
            scalarValueCondition14.Enabled = true;
            scalarValueCondition14.ExpectedValue = "1";
            scalarValueCondition14.Name = "scalarValueCondition14";
            scalarValueCondition14.NullExpected = false;
            scalarValueCondition14.ResultSet = 4;
            scalarValueCondition14.RowNumber = 1;
            // 
            // ShouldLinkEpisodesWithGenres_PretestAction
            // 
            resources.ApplyResources(ShouldLinkEpisodesWithGenres_PretestAction, "ShouldLinkEpisodesWithGenres_PretestAction");
            // 
            // ShouldLinkPersonsWithIndividualEpisodes_TestAction
            // 
            ShouldLinkPersonsWithIndividualEpisodes_TestAction.Conditions.Add(rowCountCondition10);
            ShouldLinkPersonsWithIndividualEpisodes_TestAction.Conditions.Add(rowCountCondition11);
            ShouldLinkPersonsWithIndividualEpisodes_TestAction.Conditions.Add(scalarValueCondition15);
            ShouldLinkPersonsWithIndividualEpisodes_TestAction.Conditions.Add(scalarValueCondition16);
            ShouldLinkPersonsWithIndividualEpisodes_TestAction.Conditions.Add(scalarValueCondition17);
            resources.ApplyResources(ShouldLinkPersonsWithIndividualEpisodes_TestAction, "ShouldLinkPersonsWithIndividualEpisodes_TestAction");
            // 
            // rowCountCondition10
            // 
            rowCountCondition10.Enabled = true;
            rowCountCondition10.Name = "rowCountCondition10";
            rowCountCondition10.ResultSet = 3;
            rowCountCondition10.RowCount = 2;
            // 
            // rowCountCondition11
            // 
            rowCountCondition11.Enabled = true;
            rowCountCondition11.Name = "rowCountCondition11";
            rowCountCondition11.ResultSet = 4;
            rowCountCondition11.RowCount = 1;
            // 
            // scalarValueCondition15
            // 
            scalarValueCondition15.ColumnNumber = 1;
            scalarValueCondition15.Enabled = true;
            scalarValueCondition15.ExpectedValue = "2";
            scalarValueCondition15.Name = "scalarValueCondition15";
            scalarValueCondition15.NullExpected = false;
            scalarValueCondition15.ResultSet = 3;
            scalarValueCondition15.RowNumber = 1;
            // 
            // scalarValueCondition16
            // 
            scalarValueCondition16.ColumnNumber = 1;
            scalarValueCondition16.Enabled = true;
            scalarValueCondition16.ExpectedValue = "3";
            scalarValueCondition16.Name = "scalarValueCondition16";
            scalarValueCondition16.NullExpected = false;
            scalarValueCondition16.ResultSet = 3;
            scalarValueCondition16.RowNumber = 2;
            // 
            // scalarValueCondition17
            // 
            scalarValueCondition17.ColumnNumber = 1;
            scalarValueCondition17.Enabled = true;
            scalarValueCondition17.ExpectedValue = "1";
            scalarValueCondition17.Name = "scalarValueCondition17";
            scalarValueCondition17.NullExpected = false;
            scalarValueCondition17.ResultSet = 4;
            scalarValueCondition17.RowNumber = 1;
            // 
            // ShouldLinkPersonsWithIndividualEpisodes_PretestAction
            // 
            resources.ApplyResources(ShouldLinkPersonsWithIndividualEpisodes_PretestAction, "ShouldLinkPersonsWithIndividualEpisodes_PretestAction");
            // 
            // testCleanupAction
            // 
            resources.ApplyResources(testCleanupAction, "testCleanupAction");
            // 
            // ShouldCreateSeriesInVideoData
            // 
            this.ShouldCreateSeriesInVideoData.PosttestAction = null;
            this.ShouldCreateSeriesInVideoData.PretestAction = null;
            this.ShouldCreateSeriesInVideoData.TestAction = ShouldCreateSeriesInVideo_TestAction;
            // 
            // ShouldCreateEntryInTvEpisodeWhenNotExistData
            // 
            this.ShouldCreateEntryInTvEpisodeWhenNotExistData.PosttestAction = null;
            this.ShouldCreateEntryInTvEpisodeWhenNotExistData.PretestAction = null;
            this.ShouldCreateEntryInTvEpisodeWhenNotExistData.TestAction = ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction;
            // 
            // ShouldReturnExpectedSchemaData
            // 
            this.ShouldReturnExpectedSchemaData.PosttestAction = null;
            this.ShouldReturnExpectedSchemaData.PretestAction = null;
            this.ShouldReturnExpectedSchemaData.TestAction = ShouldReturnExpectedSchema_TestAction;
            // 
            // ShouldInsertNewEpisodeWithDifferentResolutionData
            // 
            this.ShouldInsertNewEpisodeWithDifferentResolutionData.PosttestAction = null;
            this.ShouldInsertNewEpisodeWithDifferentResolutionData.PretestAction = ShouldInsertNewEpisodeWithDifferentResolution_PretestAction;
            this.ShouldInsertNewEpisodeWithDifferentResolutionData.TestAction = ShouldInsertNewEpisodeWithDifferentResolution_TestAction;
            // 
            // ShouldInsertNewEpisodeWithDifferentCodecData
            // 
            this.ShouldInsertNewEpisodeWithDifferentCodecData.PosttestAction = null;
            this.ShouldInsertNewEpisodeWithDifferentCodecData.PretestAction = ShouldInsertNewEpisodeWithDifferentCodec_PretestAction;
            this.ShouldInsertNewEpisodeWithDifferentCodecData.TestAction = ShouldInsertNewEpisodeWithDifferentCodec_TestAction;
            // 
            // ShouldInsertNewEpisodeWithExtendedData
            // 
            this.ShouldInsertNewEpisodeWithExtendedData.PosttestAction = null;
            this.ShouldInsertNewEpisodeWithExtendedData.PretestAction = ShouldInsertNewEpisodeWithExtended_PretestAction;
            this.ShouldInsertNewEpisodeWithExtendedData.TestAction = ShouldInsertNewEpisodeWithExtended_TestAction;
            // 
            // ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData
            // 
            this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData.PosttestAction = null;
            this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData.PretestAction = ShouldNotDoAnythingWhenInsertingDuplicateEpisode_PretestAction;
            this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData.TestAction = ShouldNotDoAnythingWhenInsertingDuplicateEpisode_TestAction;
            // 
            // ShouldUpdateEpisodeIfDataChangesData
            // 
            this.ShouldUpdateEpisodeIfDataChangesData.PosttestAction = null;
            this.ShouldUpdateEpisodeIfDataChangesData.PretestAction = ShouldUpdateEpisodeIfDataChanges_PretestAction;
            this.ShouldUpdateEpisodeIfDataChangesData.TestAction = ShouldUpdateEpisodeIfDataChanges_TestAction;
            // 
            // ShouldInsertRatingsOfTvEpisodeData
            // 
            this.ShouldInsertRatingsOfTvEpisodeData.PosttestAction = null;
            this.ShouldInsertRatingsOfTvEpisodeData.PretestAction = null;
            this.ShouldInsertRatingsOfTvEpisodeData.TestAction = ShouldInsertRatingsOfTvEpisode_TestAction;
            // 
            // ShouldLinkEpisodesWithGenresData
            // 
            this.ShouldLinkEpisodesWithGenresData.PosttestAction = null;
            this.ShouldLinkEpisodesWithGenresData.PretestAction = ShouldLinkEpisodesWithGenres_PretestAction;
            this.ShouldLinkEpisodesWithGenresData.TestAction = ShouldLinkEpisodesWithGenres_TestAction;
            // 
            // ShouldLinkPersonsWithIndividualEpisodesData
            // 
            this.ShouldLinkPersonsWithIndividualEpisodesData.PosttestAction = null;
            this.ShouldLinkPersonsWithIndividualEpisodesData.PretestAction = ShouldLinkPersonsWithIndividualEpisodes_PretestAction;
            this.ShouldLinkPersonsWithIndividualEpisodesData.TestAction = ShouldLinkPersonsWithIndividualEpisodes_TestAction;
            // 
            // AddTvEpisodeTests
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
        public void ShouldCreateSeriesInVideo()
        {
            SqlDatabaseTestActions testActions = this.ShouldCreateSeriesInVideoData;
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
        public void ShouldCreateEntryInTvEpisodeWhenNotExist()
        {
            SqlDatabaseTestActions testActions = this.ShouldCreateEntryInTvEpisodeWhenNotExistData;
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
        public void ShouldInsertNewEpisodeWithDifferentResolution()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertNewEpisodeWithDifferentResolutionData;
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
        public void ShouldInsertNewEpisodeWithDifferentCodec()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertNewEpisodeWithDifferentCodecData;
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
        public void ShouldInsertNewEpisodeWithExtended()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertNewEpisodeWithExtendedData;
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
        public void ShouldNotDoAnythingWhenInsertingDuplicateEpisode()
        {
            SqlDatabaseTestActions testActions = this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData;
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
        public void ShouldUpdateEpisodeIfDataChanges()
        {
            SqlDatabaseTestActions testActions = this.ShouldUpdateEpisodeIfDataChangesData;
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
        public void ShouldInsertRatingsOfTvEpisode()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertRatingsOfTvEpisodeData;
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
        public void ShouldLinkEpisodesWithGenres()
        {
            SqlDatabaseTestActions testActions = this.ShouldLinkEpisodesWithGenresData;
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
        public void ShouldLinkPersonsWithIndividualEpisodes()
        {
            SqlDatabaseTestActions testActions = this.ShouldLinkPersonsWithIndividualEpisodesData;
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










        private SqlDatabaseTestActions ShouldCreateSeriesInVideoData;
        private SqlDatabaseTestActions ShouldCreateEntryInTvEpisodeWhenNotExistData;
        private SqlDatabaseTestActions ShouldReturnExpectedSchemaData;
        private SqlDatabaseTestActions ShouldInsertNewEpisodeWithDifferentResolutionData;
        private SqlDatabaseTestActions ShouldInsertNewEpisodeWithDifferentCodecData;
        private SqlDatabaseTestActions ShouldInsertNewEpisodeWithExtendedData;
        private SqlDatabaseTestActions ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData;
        private SqlDatabaseTestActions ShouldUpdateEpisodeIfDataChangesData;
        private SqlDatabaseTestActions ShouldInsertRatingsOfTvEpisodeData;
        private SqlDatabaseTestActions ShouldLinkEpisodesWithGenresData;
        private SqlDatabaseTestActions ShouldLinkPersonsWithIndividualEpisodesData;
    }
}
