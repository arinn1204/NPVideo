using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Linq;

namespace VideoDB.UnitTests
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition15;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeOfExistingSeries_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition19;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition20;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition21;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertNewEpisodeOfExistingSeries_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenSeriesImdbIdIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenSeriesTitleIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenMpaaRatingIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition22;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition23;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition24;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenSeriesPlotIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition25;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition26;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition27;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenSeriesReleaseDateIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition28;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition29;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition30;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenEpisodeImdbIdIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition31;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition32;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition33;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenRuntimeIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition34;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition35;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition36;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition37;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition38;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition39;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenSeasonNumberIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition40;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition41;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition42;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenEpisodeNumberIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition43;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition44;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition45;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenTheEpisodeNameIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition46;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition47;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition48;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenPlotIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition49;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition50;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition51;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition52;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition53;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition54;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition55;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition56;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition57;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition58;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition59;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenResolutionIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition60;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition61;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition62;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ShouldThrowWhenCodecIsNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition63;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition64;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition65;
            this.ShouldCreateSeriesInVideoData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldCreateEntryInTvEpisodeWhenNotExistData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldReturnExpectedSchemaData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldUpdateEpisodeIfDataChangesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertRatingsOfTvEpisodeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldLinkEpisodesWithGenresData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldLinkPersonsWithIndividualEpisodesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertNewEpisodeOfExistingSeriesData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenSeriesImdbIdIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenSeriesTitleIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenMpaaRatingIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenSeriesPlotIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenSeriesReleaseDateIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenEpisodeImdbIdIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenRuntimeIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenEpisodeReleaseDateIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenSeasonNumberIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenEpisodeNumberIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenTheEpisodeNameIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenPlotIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenResolutionIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ShouldThrowWhenCodecIsNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldCreateSeriesInVideo_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldCreateEntryInTvEpisodeWhenNotExist_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldReturnExpectedSchema_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            expectedSchemaCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            rowCountCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
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
            SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            ShouldInsertNewEpisodeOfExistingSeries_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition19 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition20 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition21 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertNewEpisodeOfExistingSeries_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ShouldThrowWhenSeriesImdbIdIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenSeriesTitleIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenMpaaRatingIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition22 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition23 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition24 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenSeriesPlotIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition25 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition26 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition27 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenSeriesReleaseDateIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition28 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition29 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition30 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenEpisodeImdbIdIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition31 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition32 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition33 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenRuntimeIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition34 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition35 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition36 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition37 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition38 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition39 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenSeasonNumberIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition40 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition41 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition42 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenEpisodeNumberIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition43 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition44 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition45 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenTheEpisodeNameIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition46 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition47 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition48 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenPlotIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition49 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition50 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition51 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition52 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition53 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition54 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition55 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition56 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition57 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition58 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition59 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenResolutionIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition60 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition61 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition62 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ShouldThrowWhenCodecIsNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition63 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition64 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition65 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
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
            ShouldReturnExpectedSchema_TestAction.Conditions.Add(rowCountCondition14);
            ShouldReturnExpectedSchema_TestAction.Conditions.Add(rowCountCondition15);
            resources.ApplyResources(ShouldReturnExpectedSchema_TestAction, "ShouldReturnExpectedSchema_TestAction");
            // 
            // expectedSchemaCondition1
            // 
            expectedSchemaCondition1.Enabled = true;
            expectedSchemaCondition1.Name = "expectedSchemaCondition1";
            resources.ApplyResources(expectedSchemaCondition1, "expectedSchemaCondition1");
            expectedSchemaCondition1.Verbose = false;
            // 
            // rowCountCondition14
            // 
            rowCountCondition14.Enabled = true;
            rowCountCondition14.Name = "rowCountCondition14";
            rowCountCondition14.ResultSet = 1;
            rowCountCondition14.RowCount = 1;
            // 
            // rowCountCondition15
            // 
            rowCountCondition15.Enabled = true;
            rowCountCondition15.Name = "rowCountCondition15";
            rowCountCondition15.ResultSet = 2;
            rowCountCondition15.RowCount = 1;
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
            // SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction
            // 
            SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction.Conditions.Add(rowCountCondition13);
            SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction.Conditions.Add(rowCountCondition12);
            resources.ApplyResources(SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction, "SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction");
            // 
            // rowCountCondition13
            // 
            rowCountCondition13.Enabled = true;
            rowCountCondition13.Name = "rowCountCondition13";
            rowCountCondition13.ResultSet = 1;
            rowCountCondition13.RowCount = 1;
            // 
            // rowCountCondition12
            // 
            rowCountCondition12.Enabled = true;
            rowCountCondition12.Name = "rowCountCondition12";
            rowCountCondition12.ResultSet = 2;
            rowCountCondition12.RowCount = 1;
            // 
            // ShouldInsertNewEpisodeOfExistingSeries_TestAction
            // 
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(rowCountCondition16);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(rowCountCondition17);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(rowCountCondition18);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(scalarValueCondition18);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(scalarValueCondition19);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(scalarValueCondition20);
            ShouldInsertNewEpisodeOfExistingSeries_TestAction.Conditions.Add(scalarValueCondition21);
            resources.ApplyResources(ShouldInsertNewEpisodeOfExistingSeries_TestAction, "ShouldInsertNewEpisodeOfExistingSeries_TestAction");
            // 
            // rowCountCondition16
            // 
            rowCountCondition16.Enabled = true;
            rowCountCondition16.Name = "rowCountCondition16";
            rowCountCondition16.ResultSet = 1;
            rowCountCondition16.RowCount = 1;
            // 
            // rowCountCondition17
            // 
            rowCountCondition17.Enabled = true;
            rowCountCondition17.Name = "rowCountCondition17";
            rowCountCondition17.ResultSet = 2;
            rowCountCondition17.RowCount = 1;
            // 
            // rowCountCondition18
            // 
            rowCountCondition18.Enabled = true;
            rowCountCondition18.Name = "rowCountCondition18";
            rowCountCondition18.ResultSet = 3;
            rowCountCondition18.RowCount = 2;
            // 
            // scalarValueCondition18
            // 
            scalarValueCondition18.ColumnNumber = 1;
            scalarValueCondition18.Enabled = true;
            scalarValueCondition18.ExpectedValue = null;
            scalarValueCondition18.Name = "scalarValueCondition18";
            scalarValueCondition18.NullExpected = true;
            scalarValueCondition18.ResultSet = 3;
            scalarValueCondition18.RowNumber = 1;
            // 
            // scalarValueCondition19
            // 
            scalarValueCondition19.ColumnNumber = 2;
            scalarValueCondition19.Enabled = true;
            scalarValueCondition19.ExpectedValue = null;
            scalarValueCondition19.Name = "scalarValueCondition19";
            scalarValueCondition19.NullExpected = true;
            scalarValueCondition19.ResultSet = 3;
            scalarValueCondition19.RowNumber = 1;
            // 
            // scalarValueCondition20
            // 
            scalarValueCondition20.ColumnNumber = 1;
            scalarValueCondition20.Enabled = true;
            scalarValueCondition20.ExpectedValue = null;
            scalarValueCondition20.Name = "scalarValueCondition20";
            scalarValueCondition20.NullExpected = true;
            scalarValueCondition20.ResultSet = 3;
            scalarValueCondition20.RowNumber = 2;
            // 
            // scalarValueCondition21
            // 
            scalarValueCondition21.ColumnNumber = 2;
            scalarValueCondition21.Enabled = true;
            scalarValueCondition21.ExpectedValue = null;
            scalarValueCondition21.Name = "scalarValueCondition21";
            scalarValueCondition21.NullExpected = true;
            scalarValueCondition21.ResultSet = 3;
            scalarValueCondition21.RowNumber = 2;
            // 
            // ShouldInsertNewEpisodeOfExistingSeries_PretestAction
            // 
            resources.ApplyResources(ShouldInsertNewEpisodeOfExistingSeries_PretestAction, "ShouldInsertNewEpisodeOfExistingSeries_PretestAction");
            // 
            // ShouldThrowWhenSeriesImdbIdIsNull_TestAction
            // 
            ShouldThrowWhenSeriesImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition1);
            ShouldThrowWhenSeriesImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition2);
            ShouldThrowWhenSeriesImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(ShouldThrowWhenSeriesImdbIdIsNull_TestAction, "ShouldThrowWhenSeriesImdbIdIsNull_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "@series_imdb_id is a required parameter.";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 2;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "16";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 3;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "1";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
            // 
            // ShouldThrowWhenSeriesTitleIsNull_TestAction
            // 
            ShouldThrowWhenSeriesTitleIsNull_TestAction.Conditions.Add(scalarValueCondition4);
            ShouldThrowWhenSeriesTitleIsNull_TestAction.Conditions.Add(scalarValueCondition5);
            ShouldThrowWhenSeriesTitleIsNull_TestAction.Conditions.Add(scalarValueCondition6);
            resources.ApplyResources(ShouldThrowWhenSeriesTitleIsNull_TestAction, "ShouldThrowWhenSeriesTitleIsNull_TestAction");
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "@series_title is a required parameter.";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 1;
            scalarValueCondition4.RowNumber = 1;
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 2;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = "16";
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = false;
            scalarValueCondition5.ResultSet = 1;
            scalarValueCondition5.RowNumber = 1;
            // 
            // scalarValueCondition6
            // 
            scalarValueCondition6.ColumnNumber = 3;
            scalarValueCondition6.Enabled = true;
            scalarValueCondition6.ExpectedValue = "1";
            scalarValueCondition6.Name = "scalarValueCondition6";
            scalarValueCondition6.NullExpected = false;
            scalarValueCondition6.ResultSet = 1;
            scalarValueCondition6.RowNumber = 1;
            // 
            // ShouldThrowWhenMpaaRatingIsNull_TestAction
            // 
            ShouldThrowWhenMpaaRatingIsNull_TestAction.Conditions.Add(scalarValueCondition22);
            ShouldThrowWhenMpaaRatingIsNull_TestAction.Conditions.Add(scalarValueCondition23);
            ShouldThrowWhenMpaaRatingIsNull_TestAction.Conditions.Add(scalarValueCondition24);
            resources.ApplyResources(ShouldThrowWhenMpaaRatingIsNull_TestAction, "ShouldThrowWhenMpaaRatingIsNull_TestAction");
            // 
            // scalarValueCondition22
            // 
            scalarValueCondition22.ColumnNumber = 1;
            scalarValueCondition22.Enabled = true;
            scalarValueCondition22.ExpectedValue = "@mpaa_rating is a required parameter.";
            scalarValueCondition22.Name = "scalarValueCondition22";
            scalarValueCondition22.NullExpected = false;
            scalarValueCondition22.ResultSet = 1;
            scalarValueCondition22.RowNumber = 1;
            // 
            // scalarValueCondition23
            // 
            scalarValueCondition23.ColumnNumber = 2;
            scalarValueCondition23.Enabled = true;
            scalarValueCondition23.ExpectedValue = "16";
            scalarValueCondition23.Name = "scalarValueCondition23";
            scalarValueCondition23.NullExpected = false;
            scalarValueCondition23.ResultSet = 1;
            scalarValueCondition23.RowNumber = 1;
            // 
            // scalarValueCondition24
            // 
            scalarValueCondition24.ColumnNumber = 3;
            scalarValueCondition24.Enabled = true;
            scalarValueCondition24.ExpectedValue = "1";
            scalarValueCondition24.Name = "scalarValueCondition24";
            scalarValueCondition24.NullExpected = false;
            scalarValueCondition24.ResultSet = 1;
            scalarValueCondition24.RowNumber = 1;
            // 
            // ShouldThrowWhenSeriesPlotIsNull_TestAction
            // 
            ShouldThrowWhenSeriesPlotIsNull_TestAction.Conditions.Add(scalarValueCondition25);
            ShouldThrowWhenSeriesPlotIsNull_TestAction.Conditions.Add(scalarValueCondition26);
            ShouldThrowWhenSeriesPlotIsNull_TestAction.Conditions.Add(scalarValueCondition27);
            resources.ApplyResources(ShouldThrowWhenSeriesPlotIsNull_TestAction, "ShouldThrowWhenSeriesPlotIsNull_TestAction");
            // 
            // scalarValueCondition25
            // 
            scalarValueCondition25.ColumnNumber = 1;
            scalarValueCondition25.Enabled = true;
            scalarValueCondition25.ExpectedValue = "@series_plot is a required parameter.";
            scalarValueCondition25.Name = "scalarValueCondition25";
            scalarValueCondition25.NullExpected = false;
            scalarValueCondition25.ResultSet = 1;
            scalarValueCondition25.RowNumber = 1;
            // 
            // scalarValueCondition26
            // 
            scalarValueCondition26.ColumnNumber = 2;
            scalarValueCondition26.Enabled = true;
            scalarValueCondition26.ExpectedValue = "16";
            scalarValueCondition26.Name = "scalarValueCondition26";
            scalarValueCondition26.NullExpected = false;
            scalarValueCondition26.ResultSet = 1;
            scalarValueCondition26.RowNumber = 1;
            // 
            // scalarValueCondition27
            // 
            scalarValueCondition27.ColumnNumber = 3;
            scalarValueCondition27.Enabled = true;
            scalarValueCondition27.ExpectedValue = "1";
            scalarValueCondition27.Name = "scalarValueCondition27";
            scalarValueCondition27.NullExpected = false;
            scalarValueCondition27.ResultSet = 1;
            scalarValueCondition27.RowNumber = 1;
            // 
            // ShouldThrowWhenSeriesReleaseDateIsNull_TestAction
            // 
            ShouldThrowWhenSeriesReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition28);
            ShouldThrowWhenSeriesReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition29);
            ShouldThrowWhenSeriesReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition30);
            resources.ApplyResources(ShouldThrowWhenSeriesReleaseDateIsNull_TestAction, "ShouldThrowWhenSeriesReleaseDateIsNull_TestAction");
            // 
            // scalarValueCondition28
            // 
            scalarValueCondition28.ColumnNumber = 1;
            scalarValueCondition28.Enabled = true;
            scalarValueCondition28.ExpectedValue = "@series_release_date is a required parameter.";
            scalarValueCondition28.Name = "scalarValueCondition28";
            scalarValueCondition28.NullExpected = false;
            scalarValueCondition28.ResultSet = 1;
            scalarValueCondition28.RowNumber = 1;
            // 
            // scalarValueCondition29
            // 
            scalarValueCondition29.ColumnNumber = 2;
            scalarValueCondition29.Enabled = true;
            scalarValueCondition29.ExpectedValue = "16";
            scalarValueCondition29.Name = "scalarValueCondition29";
            scalarValueCondition29.NullExpected = false;
            scalarValueCondition29.ResultSet = 1;
            scalarValueCondition29.RowNumber = 1;
            // 
            // scalarValueCondition30
            // 
            scalarValueCondition30.ColumnNumber = 3;
            scalarValueCondition30.Enabled = true;
            scalarValueCondition30.ExpectedValue = "1";
            scalarValueCondition30.Name = "scalarValueCondition30";
            scalarValueCondition30.NullExpected = false;
            scalarValueCondition30.ResultSet = 1;
            scalarValueCondition30.RowNumber = 1;
            // 
            // ShouldThrowWhenEpisodeImdbIdIsNull_TestAction
            // 
            ShouldThrowWhenEpisodeImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition31);
            ShouldThrowWhenEpisodeImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition32);
            ShouldThrowWhenEpisodeImdbIdIsNull_TestAction.Conditions.Add(scalarValueCondition33);
            resources.ApplyResources(ShouldThrowWhenEpisodeImdbIdIsNull_TestAction, "ShouldThrowWhenEpisodeImdbIdIsNull_TestAction");
            // 
            // scalarValueCondition31
            // 
            scalarValueCondition31.ColumnNumber = 1;
            scalarValueCondition31.Enabled = true;
            scalarValueCondition31.ExpectedValue = "@episode_imdb_id is a required parameter.";
            scalarValueCondition31.Name = "scalarValueCondition31";
            scalarValueCondition31.NullExpected = false;
            scalarValueCondition31.ResultSet = 1;
            scalarValueCondition31.RowNumber = 1;
            // 
            // scalarValueCondition32
            // 
            scalarValueCondition32.ColumnNumber = 2;
            scalarValueCondition32.Enabled = true;
            scalarValueCondition32.ExpectedValue = "16";
            scalarValueCondition32.Name = "scalarValueCondition32";
            scalarValueCondition32.NullExpected = false;
            scalarValueCondition32.ResultSet = 1;
            scalarValueCondition32.RowNumber = 1;
            // 
            // scalarValueCondition33
            // 
            scalarValueCondition33.ColumnNumber = 3;
            scalarValueCondition33.Enabled = true;
            scalarValueCondition33.ExpectedValue = "1";
            scalarValueCondition33.Name = "scalarValueCondition33";
            scalarValueCondition33.NullExpected = false;
            scalarValueCondition33.ResultSet = 1;
            scalarValueCondition33.RowNumber = 1;
            // 
            // ShouldThrowWhenRuntimeIsNull_TestAction
            // 
            ShouldThrowWhenRuntimeIsNull_TestAction.Conditions.Add(scalarValueCondition34);
            ShouldThrowWhenRuntimeIsNull_TestAction.Conditions.Add(scalarValueCondition35);
            ShouldThrowWhenRuntimeIsNull_TestAction.Conditions.Add(scalarValueCondition36);
            resources.ApplyResources(ShouldThrowWhenRuntimeIsNull_TestAction, "ShouldThrowWhenRuntimeIsNull_TestAction");
            // 
            // scalarValueCondition34
            // 
            scalarValueCondition34.ColumnNumber = 1;
            scalarValueCondition34.Enabled = true;
            scalarValueCondition34.ExpectedValue = "@runtime is a required parameter.";
            scalarValueCondition34.Name = "scalarValueCondition34";
            scalarValueCondition34.NullExpected = false;
            scalarValueCondition34.ResultSet = 1;
            scalarValueCondition34.RowNumber = 1;
            // 
            // scalarValueCondition35
            // 
            scalarValueCondition35.ColumnNumber = 2;
            scalarValueCondition35.Enabled = true;
            scalarValueCondition35.ExpectedValue = "16";
            scalarValueCondition35.Name = "scalarValueCondition35";
            scalarValueCondition35.NullExpected = false;
            scalarValueCondition35.ResultSet = 1;
            scalarValueCondition35.RowNumber = 1;
            // 
            // scalarValueCondition36
            // 
            scalarValueCondition36.ColumnNumber = 3;
            scalarValueCondition36.Enabled = true;
            scalarValueCondition36.ExpectedValue = "1";
            scalarValueCondition36.Name = "scalarValueCondition36";
            scalarValueCondition36.NullExpected = false;
            scalarValueCondition36.ResultSet = 1;
            scalarValueCondition36.RowNumber = 1;
            // 
            // ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction
            // 
            ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition37);
            ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition38);
            ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction.Conditions.Add(scalarValueCondition39);
            resources.ApplyResources(ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction, "ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction");
            // 
            // scalarValueCondition37
            // 
            scalarValueCondition37.ColumnNumber = 1;
            scalarValueCondition37.Enabled = true;
            scalarValueCondition37.ExpectedValue = "@episode_release_date is a required parameter.";
            scalarValueCondition37.Name = "scalarValueCondition37";
            scalarValueCondition37.NullExpected = false;
            scalarValueCondition37.ResultSet = 1;
            scalarValueCondition37.RowNumber = 1;
            // 
            // scalarValueCondition38
            // 
            scalarValueCondition38.ColumnNumber = 2;
            scalarValueCondition38.Enabled = true;
            scalarValueCondition38.ExpectedValue = "16";
            scalarValueCondition38.Name = "scalarValueCondition38";
            scalarValueCondition38.NullExpected = false;
            scalarValueCondition38.ResultSet = 1;
            scalarValueCondition38.RowNumber = 1;
            // 
            // scalarValueCondition39
            // 
            scalarValueCondition39.ColumnNumber = 3;
            scalarValueCondition39.Enabled = true;
            scalarValueCondition39.ExpectedValue = "1";
            scalarValueCondition39.Name = "scalarValueCondition39";
            scalarValueCondition39.NullExpected = false;
            scalarValueCondition39.ResultSet = 1;
            scalarValueCondition39.RowNumber = 1;
            // 
            // ShouldThrowWhenSeasonNumberIsNull_TestAction
            // 
            ShouldThrowWhenSeasonNumberIsNull_TestAction.Conditions.Add(scalarValueCondition40);
            ShouldThrowWhenSeasonNumberIsNull_TestAction.Conditions.Add(scalarValueCondition41);
            ShouldThrowWhenSeasonNumberIsNull_TestAction.Conditions.Add(scalarValueCondition42);
            resources.ApplyResources(ShouldThrowWhenSeasonNumberIsNull_TestAction, "ShouldThrowWhenSeasonNumberIsNull_TestAction");
            // 
            // scalarValueCondition40
            // 
            scalarValueCondition40.ColumnNumber = 1;
            scalarValueCondition40.Enabled = true;
            scalarValueCondition40.ExpectedValue = "@season_number is a required parameter.";
            scalarValueCondition40.Name = "scalarValueCondition40";
            scalarValueCondition40.NullExpected = false;
            scalarValueCondition40.ResultSet = 1;
            scalarValueCondition40.RowNumber = 1;
            // 
            // scalarValueCondition41
            // 
            scalarValueCondition41.ColumnNumber = 2;
            scalarValueCondition41.Enabled = true;
            scalarValueCondition41.ExpectedValue = "16";
            scalarValueCondition41.Name = "scalarValueCondition41";
            scalarValueCondition41.NullExpected = false;
            scalarValueCondition41.ResultSet = 1;
            scalarValueCondition41.RowNumber = 1;
            // 
            // scalarValueCondition42
            // 
            scalarValueCondition42.ColumnNumber = 3;
            scalarValueCondition42.Enabled = true;
            scalarValueCondition42.ExpectedValue = "1";
            scalarValueCondition42.Name = "scalarValueCondition42";
            scalarValueCondition42.NullExpected = false;
            scalarValueCondition42.ResultSet = 1;
            scalarValueCondition42.RowNumber = 1;
            // 
            // ShouldThrowWhenEpisodeNumberIsNull_TestAction
            // 
            ShouldThrowWhenEpisodeNumberIsNull_TestAction.Conditions.Add(scalarValueCondition43);
            ShouldThrowWhenEpisodeNumberIsNull_TestAction.Conditions.Add(scalarValueCondition44);
            ShouldThrowWhenEpisodeNumberIsNull_TestAction.Conditions.Add(scalarValueCondition45);
            resources.ApplyResources(ShouldThrowWhenEpisodeNumberIsNull_TestAction, "ShouldThrowWhenEpisodeNumberIsNull_TestAction");
            // 
            // scalarValueCondition43
            // 
            scalarValueCondition43.ColumnNumber = 1;
            scalarValueCondition43.Enabled = true;
            scalarValueCondition43.ExpectedValue = "@episode_number is a required parameter.";
            scalarValueCondition43.Name = "scalarValueCondition43";
            scalarValueCondition43.NullExpected = false;
            scalarValueCondition43.ResultSet = 1;
            scalarValueCondition43.RowNumber = 1;
            // 
            // scalarValueCondition44
            // 
            scalarValueCondition44.ColumnNumber = 2;
            scalarValueCondition44.Enabled = true;
            scalarValueCondition44.ExpectedValue = "16";
            scalarValueCondition44.Name = "scalarValueCondition44";
            scalarValueCondition44.NullExpected = false;
            scalarValueCondition44.ResultSet = 1;
            scalarValueCondition44.RowNumber = 1;
            // 
            // scalarValueCondition45
            // 
            scalarValueCondition45.ColumnNumber = 3;
            scalarValueCondition45.Enabled = true;
            scalarValueCondition45.ExpectedValue = "1";
            scalarValueCondition45.Name = "scalarValueCondition45";
            scalarValueCondition45.NullExpected = false;
            scalarValueCondition45.ResultSet = 1;
            scalarValueCondition45.RowNumber = 1;
            // 
            // ShouldThrowWhenTheEpisodeNameIsNull_TestAction
            // 
            ShouldThrowWhenTheEpisodeNameIsNull_TestAction.Conditions.Add(scalarValueCondition46);
            ShouldThrowWhenTheEpisodeNameIsNull_TestAction.Conditions.Add(scalarValueCondition47);
            ShouldThrowWhenTheEpisodeNameIsNull_TestAction.Conditions.Add(scalarValueCondition48);
            resources.ApplyResources(ShouldThrowWhenTheEpisodeNameIsNull_TestAction, "ShouldThrowWhenTheEpisodeNameIsNull_TestAction");
            // 
            // scalarValueCondition46
            // 
            scalarValueCondition46.ColumnNumber = 1;
            scalarValueCondition46.Enabled = true;
            scalarValueCondition46.ExpectedValue = "@episode_name is a required parameter.";
            scalarValueCondition46.Name = "scalarValueCondition46";
            scalarValueCondition46.NullExpected = false;
            scalarValueCondition46.ResultSet = 1;
            scalarValueCondition46.RowNumber = 1;
            // 
            // scalarValueCondition47
            // 
            scalarValueCondition47.ColumnNumber = 2;
            scalarValueCondition47.Enabled = true;
            scalarValueCondition47.ExpectedValue = "16";
            scalarValueCondition47.Name = "scalarValueCondition47";
            scalarValueCondition47.NullExpected = false;
            scalarValueCondition47.ResultSet = 1;
            scalarValueCondition47.RowNumber = 1;
            // 
            // scalarValueCondition48
            // 
            scalarValueCondition48.ColumnNumber = 3;
            scalarValueCondition48.Enabled = true;
            scalarValueCondition48.ExpectedValue = "1";
            scalarValueCondition48.Name = "scalarValueCondition48";
            scalarValueCondition48.NullExpected = false;
            scalarValueCondition48.ResultSet = 1;
            scalarValueCondition48.RowNumber = 1;
            // 
            // ShouldThrowWhenPlotIsNull_TestAction
            // 
            ShouldThrowWhenPlotIsNull_TestAction.Conditions.Add(scalarValueCondition49);
            ShouldThrowWhenPlotIsNull_TestAction.Conditions.Add(scalarValueCondition50);
            ShouldThrowWhenPlotIsNull_TestAction.Conditions.Add(scalarValueCondition51);
            resources.ApplyResources(ShouldThrowWhenPlotIsNull_TestAction, "ShouldThrowWhenPlotIsNull_TestAction");
            // 
            // scalarValueCondition49
            // 
            scalarValueCondition49.ColumnNumber = 1;
            scalarValueCondition49.Enabled = true;
            scalarValueCondition49.ExpectedValue = "@plot is a required parameter.";
            scalarValueCondition49.Name = "scalarValueCondition49";
            scalarValueCondition49.NullExpected = false;
            scalarValueCondition49.ResultSet = 1;
            scalarValueCondition49.RowNumber = 1;
            // 
            // scalarValueCondition50
            // 
            scalarValueCondition50.ColumnNumber = 2;
            scalarValueCondition50.Enabled = true;
            scalarValueCondition50.ExpectedValue = "16";
            scalarValueCondition50.Name = "scalarValueCondition50";
            scalarValueCondition50.NullExpected = false;
            scalarValueCondition50.ResultSet = 1;
            scalarValueCondition50.RowNumber = 1;
            // 
            // scalarValueCondition51
            // 
            scalarValueCondition51.ColumnNumber = 3;
            scalarValueCondition51.Enabled = true;
            scalarValueCondition51.ExpectedValue = "1";
            scalarValueCondition51.Name = "scalarValueCondition51";
            scalarValueCondition51.NullExpected = false;
            scalarValueCondition51.ResultSet = 1;
            scalarValueCondition51.RowNumber = 1;
            // 
            // ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction
            // 
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction.Conditions.Add(rowCountCondition3);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition52);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition53);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition54);
            ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition55);
            resources.ApplyResources(ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction, "ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction");
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 3;
            rowCountCondition3.RowCount = 1;
            // 
            // scalarValueCondition52
            // 
            scalarValueCondition52.ColumnNumber = 1;
            scalarValueCondition52.Enabled = true;
            scalarValueCondition52.ExpectedValue = "1";
            scalarValueCondition52.Name = "scalarValueCondition52";
            scalarValueCondition52.NullExpected = false;
            scalarValueCondition52.ResultSet = 3;
            scalarValueCondition52.RowNumber = 1;
            // 
            // scalarValueCondition53
            // 
            scalarValueCondition53.ColumnNumber = 2;
            scalarValueCondition53.Enabled = true;
            scalarValueCondition53.ExpectedValue = "1080p";
            scalarValueCondition53.Name = "scalarValueCondition53";
            scalarValueCondition53.NullExpected = false;
            scalarValueCondition53.ResultSet = 3;
            scalarValueCondition53.RowNumber = 1;
            // 
            // scalarValueCondition54
            // 
            scalarValueCondition54.ColumnNumber = 3;
            scalarValueCondition54.Enabled = true;
            scalarValueCondition54.ExpectedValue = "x265";
            scalarValueCondition54.Name = "scalarValueCondition54";
            scalarValueCondition54.NullExpected = false;
            scalarValueCondition54.ResultSet = 3;
            scalarValueCondition54.RowNumber = 1;
            // 
            // scalarValueCondition55
            // 
            scalarValueCondition55.ColumnNumber = 4;
            scalarValueCondition55.Enabled = true;
            scalarValueCondition55.ExpectedValue = "REPACK";
            scalarValueCondition55.Name = "scalarValueCondition55";
            scalarValueCondition55.NullExpected = false;
            scalarValueCondition55.ResultSet = 3;
            scalarValueCondition55.RowNumber = 1;
            // 
            // ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction
            // 
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(rowCountCondition4);
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition56);
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition57);
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition58);
            ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction.Conditions.Add(scalarValueCondition59);
            resources.ApplyResources(ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction, "ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction");
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 3;
            rowCountCondition4.RowCount = 1;
            // 
            // scalarValueCondition56
            // 
            scalarValueCondition56.ColumnNumber = 1;
            scalarValueCondition56.Enabled = true;
            scalarValueCondition56.ExpectedValue = "1";
            scalarValueCondition56.Name = "scalarValueCondition56";
            scalarValueCondition56.NullExpected = false;
            scalarValueCondition56.ResultSet = 3;
            scalarValueCondition56.RowNumber = 1;
            // 
            // scalarValueCondition57
            // 
            scalarValueCondition57.ColumnNumber = 2;
            scalarValueCondition57.Enabled = true;
            scalarValueCondition57.ExpectedValue = "1080p";
            scalarValueCondition57.Name = "scalarValueCondition57";
            scalarValueCondition57.NullExpected = false;
            scalarValueCondition57.ResultSet = 3;
            scalarValueCondition57.RowNumber = 1;
            // 
            // scalarValueCondition58
            // 
            scalarValueCondition58.ColumnNumber = 3;
            scalarValueCondition58.Enabled = true;
            scalarValueCondition58.ExpectedValue = "x265";
            scalarValueCondition58.Name = "scalarValueCondition58";
            scalarValueCondition58.NullExpected = false;
            scalarValueCondition58.ResultSet = 3;
            scalarValueCondition58.RowNumber = 1;
            // 
            // scalarValueCondition59
            // 
            scalarValueCondition59.ColumnNumber = 4;
            scalarValueCondition59.Enabled = true;
            scalarValueCondition59.ExpectedValue = null;
            scalarValueCondition59.Name = "scalarValueCondition59";
            scalarValueCondition59.NullExpected = true;
            scalarValueCondition59.ResultSet = 3;
            scalarValueCondition59.RowNumber = 1;
            // 
            // ShouldThrowWhenResolutionIsNull_TestAction
            // 
            ShouldThrowWhenResolutionIsNull_TestAction.Conditions.Add(scalarValueCondition60);
            ShouldThrowWhenResolutionIsNull_TestAction.Conditions.Add(scalarValueCondition61);
            ShouldThrowWhenResolutionIsNull_TestAction.Conditions.Add(scalarValueCondition62);
            resources.ApplyResources(ShouldThrowWhenResolutionIsNull_TestAction, "ShouldThrowWhenResolutionIsNull_TestAction");
            // 
            // scalarValueCondition60
            // 
            scalarValueCondition60.ColumnNumber = 1;
            scalarValueCondition60.Enabled = true;
            scalarValueCondition60.ExpectedValue = "@resolution is a required parameter.";
            scalarValueCondition60.Name = "scalarValueCondition60";
            scalarValueCondition60.NullExpected = false;
            scalarValueCondition60.ResultSet = 1;
            scalarValueCondition60.RowNumber = 1;
            // 
            // scalarValueCondition61
            // 
            scalarValueCondition61.ColumnNumber = 2;
            scalarValueCondition61.Enabled = true;
            scalarValueCondition61.ExpectedValue = "16";
            scalarValueCondition61.Name = "scalarValueCondition61";
            scalarValueCondition61.NullExpected = false;
            scalarValueCondition61.ResultSet = 1;
            scalarValueCondition61.RowNumber = 1;
            // 
            // scalarValueCondition62
            // 
            scalarValueCondition62.ColumnNumber = 3;
            scalarValueCondition62.Enabled = true;
            scalarValueCondition62.ExpectedValue = "1";
            scalarValueCondition62.Name = "scalarValueCondition62";
            scalarValueCondition62.NullExpected = false;
            scalarValueCondition62.ResultSet = 1;
            scalarValueCondition62.RowNumber = 1;
            // 
            // ShouldThrowWhenCodecIsNull_TestAction
            // 
            ShouldThrowWhenCodecIsNull_TestAction.Conditions.Add(scalarValueCondition63);
            ShouldThrowWhenCodecIsNull_TestAction.Conditions.Add(scalarValueCondition64);
            ShouldThrowWhenCodecIsNull_TestAction.Conditions.Add(scalarValueCondition65);
            resources.ApplyResources(ShouldThrowWhenCodecIsNull_TestAction, "ShouldThrowWhenCodecIsNull_TestAction");
            // 
            // scalarValueCondition63
            // 
            scalarValueCondition63.ColumnNumber = 1;
            scalarValueCondition63.Enabled = true;
            scalarValueCondition63.ExpectedValue = "@codec is a required parameter.";
            scalarValueCondition63.Name = "scalarValueCondition63";
            scalarValueCondition63.NullExpected = false;
            scalarValueCondition63.ResultSet = 1;
            scalarValueCondition63.RowNumber = 1;
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
            // SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData
            // 
            this.SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData.PosttestAction = null;
            this.SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData.PretestAction = null;
            this.SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData.TestAction = SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation_TestAction;
            // 
            // ShouldInsertNewEpisodeOfExistingSeriesData
            // 
            this.ShouldInsertNewEpisodeOfExistingSeriesData.PosttestAction = null;
            this.ShouldInsertNewEpisodeOfExistingSeriesData.PretestAction = ShouldInsertNewEpisodeOfExistingSeries_PretestAction;
            this.ShouldInsertNewEpisodeOfExistingSeriesData.TestAction = ShouldInsertNewEpisodeOfExistingSeries_TestAction;
            // 
            // ShouldThrowWhenSeriesImdbIdIsNullData
            // 
            this.ShouldThrowWhenSeriesImdbIdIsNullData.PosttestAction = null;
            this.ShouldThrowWhenSeriesImdbIdIsNullData.PretestAction = null;
            this.ShouldThrowWhenSeriesImdbIdIsNullData.TestAction = ShouldThrowWhenSeriesImdbIdIsNull_TestAction;
            // 
            // ShouldThrowWhenSeriesTitleIsNullData
            // 
            this.ShouldThrowWhenSeriesTitleIsNullData.PosttestAction = null;
            this.ShouldThrowWhenSeriesTitleIsNullData.PretestAction = null;
            this.ShouldThrowWhenSeriesTitleIsNullData.TestAction = ShouldThrowWhenSeriesTitleIsNull_TestAction;
            // 
            // ShouldThrowWhenMpaaRatingIsNullData
            // 
            this.ShouldThrowWhenMpaaRatingIsNullData.PosttestAction = null;
            this.ShouldThrowWhenMpaaRatingIsNullData.PretestAction = null;
            this.ShouldThrowWhenMpaaRatingIsNullData.TestAction = ShouldThrowWhenMpaaRatingIsNull_TestAction;
            // 
            // ShouldThrowWhenSeriesPlotIsNullData
            // 
            this.ShouldThrowWhenSeriesPlotIsNullData.PosttestAction = null;
            this.ShouldThrowWhenSeriesPlotIsNullData.PretestAction = null;
            this.ShouldThrowWhenSeriesPlotIsNullData.TestAction = ShouldThrowWhenSeriesPlotIsNull_TestAction;
            // 
            // ShouldThrowWhenSeriesReleaseDateIsNullData
            // 
            this.ShouldThrowWhenSeriesReleaseDateIsNullData.PosttestAction = null;
            this.ShouldThrowWhenSeriesReleaseDateIsNullData.PretestAction = null;
            this.ShouldThrowWhenSeriesReleaseDateIsNullData.TestAction = ShouldThrowWhenSeriesReleaseDateIsNull_TestAction;
            // 
            // ShouldThrowWhenEpisodeImdbIdIsNullData
            // 
            this.ShouldThrowWhenEpisodeImdbIdIsNullData.PosttestAction = null;
            this.ShouldThrowWhenEpisodeImdbIdIsNullData.PretestAction = null;
            this.ShouldThrowWhenEpisodeImdbIdIsNullData.TestAction = ShouldThrowWhenEpisodeImdbIdIsNull_TestAction;
            // 
            // ShouldThrowWhenRuntimeIsNullData
            // 
            this.ShouldThrowWhenRuntimeIsNullData.PosttestAction = null;
            this.ShouldThrowWhenRuntimeIsNullData.PretestAction = null;
            this.ShouldThrowWhenRuntimeIsNullData.TestAction = ShouldThrowWhenRuntimeIsNull_TestAction;
            // 
            // ShouldThrowWhenEpisodeReleaseDateIsNullData
            // 
            this.ShouldThrowWhenEpisodeReleaseDateIsNullData.PosttestAction = null;
            this.ShouldThrowWhenEpisodeReleaseDateIsNullData.PretestAction = null;
            this.ShouldThrowWhenEpisodeReleaseDateIsNullData.TestAction = ShouldThrowWhenEpisodeReleaseDateIsNull_TestAction;
            // 
            // ShouldThrowWhenSeasonNumberIsNullData
            // 
            this.ShouldThrowWhenSeasonNumberIsNullData.PosttestAction = null;
            this.ShouldThrowWhenSeasonNumberIsNullData.PretestAction = null;
            this.ShouldThrowWhenSeasonNumberIsNullData.TestAction = ShouldThrowWhenSeasonNumberIsNull_TestAction;
            // 
            // ShouldThrowWhenEpisodeNumberIsNullData
            // 
            this.ShouldThrowWhenEpisodeNumberIsNullData.PosttestAction = null;
            this.ShouldThrowWhenEpisodeNumberIsNullData.PretestAction = null;
            this.ShouldThrowWhenEpisodeNumberIsNullData.TestAction = ShouldThrowWhenEpisodeNumberIsNull_TestAction;
            // 
            // ShouldThrowWhenTheEpisodeNameIsNullData
            // 
            this.ShouldThrowWhenTheEpisodeNameIsNullData.PosttestAction = null;
            this.ShouldThrowWhenTheEpisodeNameIsNullData.PretestAction = null;
            this.ShouldThrowWhenTheEpisodeNameIsNullData.TestAction = ShouldThrowWhenTheEpisodeNameIsNull_TestAction;
            // 
            // ShouldThrowWhenPlotIsNullData
            // 
            this.ShouldThrowWhenPlotIsNullData.PosttestAction = null;
            this.ShouldThrowWhenPlotIsNullData.PretestAction = null;
            this.ShouldThrowWhenPlotIsNullData.TestAction = ShouldThrowWhenPlotIsNull_TestAction;
            // 
            // ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData
            // 
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData.PosttestAction = null;
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData.PretestAction = null;
            this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData.TestAction = ShouldInsertCodecAndResolutionAndExtendedIntoMetadata_TestAction;
            // 
            // ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData
            // 
            this.ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData.PosttestAction = null;
            this.ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData.PretestAction = null;
            this.ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData.TestAction = ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata_TestAction;
            // 
            // ShouldThrowWhenResolutionIsNullData
            // 
            this.ShouldThrowWhenResolutionIsNullData.PosttestAction = null;
            this.ShouldThrowWhenResolutionIsNullData.PretestAction = null;
            this.ShouldThrowWhenResolutionIsNullData.TestAction = ShouldThrowWhenResolutionIsNull_TestAction;
            // 
            // ShouldThrowWhenCodecIsNullData
            // 
            this.ShouldThrowWhenCodecIsNullData.PosttestAction = null;
            this.ShouldThrowWhenCodecIsNullData.PretestAction = null;
            this.ShouldThrowWhenCodecIsNullData.TestAction = ShouldThrowWhenCodecIsNull_TestAction;
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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) 
        //{
        //}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup() 
        //{ 
        //}
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
        [TestMethod()]
        public void SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformation()
        {
            SqlDatabaseTestActions testActions = this.SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData;
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
        public void ShouldInsertNewEpisodeOfExistingSeries()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertNewEpisodeOfExistingSeriesData;
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
        public void ShouldThrowWhenSeriesImdbIdIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenSeriesImdbIdIsNullData;
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
        public void ShouldThrowWhenSeriesTitleIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenSeriesTitleIsNullData;
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
        public void ShouldThrowWhenMpaaRatingIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenMpaaRatingIsNullData;
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
        public void ShouldThrowWhenSeriesPlotIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenSeriesPlotIsNullData;
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
        public void ShouldThrowWhenSeriesReleaseDateIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenSeriesReleaseDateIsNullData;
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
        public void ShouldThrowWhenEpisodeImdbIdIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenEpisodeImdbIdIsNullData;
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
        public void ShouldThrowWhenRuntimeIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenRuntimeIsNullData;
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
        public void ShouldThrowWhenEpisodeReleaseDateIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenEpisodeReleaseDateIsNullData;
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
        public void ShouldThrowWhenSeasonNumberIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenSeasonNumberIsNullData;
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
        public void ShouldThrowWhenEpisodeNumberIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenEpisodeNumberIsNullData;
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
        public void ShouldThrowWhenTheEpisodeNameIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenTheEpisodeNameIsNullData;
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
        public void ShouldThrowWhenPlotIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenPlotIsNullData;
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
        public void ShouldInsertCodecAndResolutionAndExtendedIntoMetadata()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData;
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
        public void ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadata()
        {
            SqlDatabaseTestActions testActions = this.ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData;
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
        public void ShouldThrowWhenResolutionIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenResolutionIsNullData;
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
        public void ShouldThrowWhenCodecIsNull()
        {
            SqlDatabaseTestActions testActions = this.ShouldThrowWhenCodecIsNullData;
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
        private SqlDatabaseTestActions ShouldNotDoAnythingWhenInsertingDuplicateEpisodeData;
        private SqlDatabaseTestActions ShouldUpdateEpisodeIfDataChangesData;
        private SqlDatabaseTestActions ShouldInsertRatingsOfTvEpisodeData;
        private SqlDatabaseTestActions ShouldLinkEpisodesWithGenresData;
        private SqlDatabaseTestActions ShouldLinkPersonsWithIndividualEpisodesData;
        private SqlDatabaseTestActions SuccessfullyReturnsSeriesInformationAsWellAsEpisodeInformationData;
        private SqlDatabaseTestActions ShouldInsertNewEpisodeOfExistingSeriesData;
        private SqlDatabaseTestActions ShouldThrowWhenSeriesImdbIdIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenSeriesTitleIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenMpaaRatingIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenSeriesPlotIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenSeriesReleaseDateIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenEpisodeImdbIdIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenRuntimeIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenEpisodeReleaseDateIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenSeasonNumberIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenEpisodeNumberIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenTheEpisodeNameIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenPlotIsNullData;
        private SqlDatabaseTestActions ShouldInsertCodecAndResolutionAndExtendedIntoMetadataData;
        private SqlDatabaseTestActions ShouldInsertCodecAndResolutionAndNullExtendedIntoMetadataData;
        private SqlDatabaseTestActions ShouldThrowWhenResolutionIsNullData;
        private SqlDatabaseTestActions ShouldThrowWhenCodecIsNullData;
    }
}
