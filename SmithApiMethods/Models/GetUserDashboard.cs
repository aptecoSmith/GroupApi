using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMethods1.OrbitApi.Models
{
    public class GetUserDashboard
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class RecordSet
        {
            public string type { get; set; }
            public string keyVariableName { get; set; }
            public bool byReference { get; set; }
            public string path { get; set; }
            public bool transient { get; set; }
            public string values { get; set; }
            public int minOccurs { get; set; }
        }

        public class Logic
        {
            public string operation { get; set; }
            public List<object> operands { get; set; }
            public string tableName { get; set; }
            public string name { get; set; }
        }

        public class AgeRule
        {
            public int rangeLow { get; set; }
            public int rangeHigh { get; set; }
            public string units { get; set; }
            public string relativeTo { get; set; }
            public string referenceType { get; set; }
            public DateTime referenceDate { get; set; }
        }

        public class DateRule
        {
            public string patternFrequency { get; set; }
            public int patternInterval { get; set; }
            public string patternType { get; set; }
            public List<string> patternDaysOfWeek { get; set; }
            public int patternDayOfMonth { get; set; }
            public int patternMonthOfYear { get; set; }
            public string patternOccurrenceOfDayInMonth { get; set; }
            public string startRangeLimit { get; set; }
            public DateTime rangeStartDate { get; set; }
            public string startRangeRelative { get; set; }
            public string startRangeOffsetDirection { get; set; }
            public int startRangeOffset { get; set; }
            public string startRangeOffsetUnits { get; set; }
            public string endRangeLimit { get; set; }
            public DateTime rangeEndDate { get; set; }
            public string endRangeRelative { get; set; }
            public string endRangeOffsetDirection { get; set; }
            public int endRangeOffset { get; set; }
            public string endRangeOffsetUnits { get; set; }
            public int rangeMaxOccurrences { get; set; }
        }

        public class ListRule
        {
            public string bandingType { get; set; }
            public string list { get; set; }
            public string variableName { get; set; }
        }

        public class TimeRule
        {
            public string rangeLow { get; set; }
            public string rangeHigh { get; set; }
        }

        public class ValueRule
        {
            public AgeRule ageRule { get; set; }
            public DateRule dateRule { get; set; }
            public ListRule listRule { get; set; }
            public TimeRule timeRule { get; set; }
            public string predefinedRule { get; set; }
            public string name { get; set; }
        }

        public class ExpressionRule
        {
            public string tableName { get; set; }
            public List<object> queries { get; set; }
            public string desc { get; set; }
            public string displayText { get; set; }
            public string serverText { get; set; }
            public List<string> queryDescriptions { get; set; }
            public string outputType { get; set; }
            public int stringSize { get; set; }
        }

        public class Criteria
        {
            public string variableName { get; set; }
            public string path { get; set; }
            public bool include { get; set; }
            public string logic { get; set; }
            public bool ignoreCase { get; set; }
            public string textMatchType { get; set; }
            public List<ValueRule> valueRules { get; set; }
            public ExpressionRule expressionRule { get; set; }
            public string todayAt { get; set; }
            public string tableName { get; set; }
            public string name { get; set; }
        }

        public class SubSelection
        {
            public bool byReference { get; set; }
            public string path { get; set; }
        }

        public class AudienceReference
        {
            public int audienceId { get; set; }
            public string version { get; set; }
            public bool include { get; set; }
            public string tableName { get; set; }
        }

        public class FileReference
        {
            public string type { get; set; }
            public string keyVariable { get; set; }
            public string path { get; set; }
            public int records { get; set; }
            public bool include { get; set; }
            public string tableName { get; set; }
        }

        public class Clause
        {
            public Logic logic { get; set; }
            public Criteria criteria { get; set; }
            public SubSelection subSelection { get; set; }
            public AudienceReference audienceReference { get; set; }
            public FileReference fileReference { get; set; }
        }

        public class Rule
        {
            public Clause clause { get; set; }
        }

        public class Frequency
        {
            public string values { get; set; }
        }

        public class Recency
        {
            public string variableName { get; set; }
            public string sequence { get; set; }
            public string direction { get; set; }
            public int value { get; set; }
            public bool distinct { get; set; }
        }

        public class Value
        {
            public string variableName { get; set; }
            public string action { get; set; }
            public string values { get; set; }
        }

        public class Rfv
        {
            public Frequency frequency { get; set; }
            public Recency recency { get; set; }
            public Value value { get; set; }
            public string groupingTable { get; set; }
            public string transactionalTable { get; set; }
        }

        public class NPer
        {
            public Recency recency { get; set; }
            public string groupingTableName { get; set; }
            public string transactionalTableName { get; set; }
        }

        public class OrderExpression
        {
            public string tableName { get; set; }
            public List<object> queries { get; set; }
            public string desc { get; set; }
            public string displayText { get; set; }
            public string serverText { get; set; }
            public List<string> queryDescriptions { get; set; }
            public string outputType { get; set; }
            public int stringSize { get; set; }
        }

        public class TopN
        {
            public string variableName { get; set; }
            public OrderExpression orderExpression { get; set; }
            public string expression { get; set; }
            public string direction { get; set; }
            public int value { get; set; }
            public int percent { get; set; }
            public int minValue { get; set; }
            public int maxValue { get; set; }
            public string sequence { get; set; }
            public string groupingVariableName { get; set; }
            public string groupingSequenceVariableName { get; set; }
            public bool groupingAscending { get; set; }
            public string groupingSequence { get; set; }
            public int groupMax { get; set; }
        }

        public class Fraction
        {
            public int numerator { get; set; }
            public int denominator { get; set; }
        }

        public class Limits
        {
            public string sampling { get; set; }
            public bool stopAtLimit { get; set; }
            public int total { get; set; }
            public string type { get; set; }
            public int startAt { get; set; }
            public int percent { get; set; }
            public Fraction fraction { get; set; }
        }

        public class Selection
        {
            public bool ancestorCounts { get; set; }
            public RecordSet recordSet { get; set; }
            public Rule rule { get; set; }
            public Rfv rfv { get; set; }
            public NPer nPer { get; set; }
            public TopN topN { get; set; }
            public Limits limits { get; set; }
            public string tableName { get; set; }
            public string name { get; set; }
        }

        public class BaseQuery
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class Size
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class NotesAlignment
        {
            public string notesPosition { get; set; }
            public string notesContentVerticalAlignment { get; set; }
            public string notesContentHorizontalAlignment { get; set; }
        }

        public class Breakpoint
        {
            public string breakpoint { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public Size size { get; set; }
            public NotesAlignment notesAlignment { get; set; }
        }

        public class Query
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class Banding
        {
            public string type { get; set; }
            public string customValues { get; set; }
        }

        public class FilterQuery
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class Expression
        {
            public string tableName { get; set; }
            public List<object> queries { get; set; }
            public string desc { get; set; }
            public string displayText { get; set; }
            public string serverText { get; set; }
            public List<string> queryDescriptions { get; set; }
            public string outputType { get; set; }
            public int stringSize { get; set; }
        }

        public class Dimension
        {
            public string id { get; set; }
            public string type { get; set; }
            public Query query { get; set; }
            public string variableName { get; set; }
            public Banding banding { get; set; }
            public string function { get; set; }
            public bool noneCell { get; set; }
            public bool omitUnclassified { get; set; }
            public FilterQuery filterQuery { get; set; }
            public Expression expression { get; set; }
            public int minimumCategoryCount { get; set; }
            public int topNCategoryCount { get; set; }
            public int percentageOfMaximumCategoryThreshold { get; set; }
        }

        public class Measure
        {
            public string id { get; set; }
            public string resolveTableName { get; set; }
            public string function { get; set; }
            public string variableName { get; set; }
            public Query query { get; set; }
            public FilterQuery filterQuery { get; set; }
            public Expression expression { get; set; }
            public string sort { get; set; }
        }

        public class CubeSpecification
        {
            public List<Dimension> dimensions { get; set; }
            public List<Measure> measures { get; set; }
            public string subTotals { get; set; }
        }

        public class ParetoSpecification
        {
            public string valueVariableName { get; set; }
            public string categoryVariableName { get; set; }
            public int numberOfBands { get; set; }
            public string resolveTableName { get; set; }
        }

        public class Claus
        {
            public Logic logic { get; set; }
            public Criteria criteria { get; set; }
            public SubSelection subSelection { get; set; }
            public AudienceReference audienceReference { get; set; }
            public FileReference fileReference { get; set; }
        }

        public class TableFilter
        {
            public string tableName { get; set; }
            public List<Claus> clauses { get; set; }
        }

        public class Filter
        {
            public string id { get; set; }
            public List<TableFilter> tableFilters { get; set; }
        }

        public class Operand
        {
            public string filterId { get; set; }
        }

        public class Structure
        {
            public string id { get; set; }
            public string operation { get; set; }
            public List<Operand> operands { get; set; }
        }

        public class FilterDefinition
        {
            public List<Filter> filters { get; set; }
            public Structure structure { get; set; }
        }

        public class Set
        {
            public string id { get; set; }
            public string name { get; set; }
            public string colour { get; set; }
            public FilterDefinition filterDefinition { get; set; }
        }

        public class VennSpecification
        {
            public List<Measure> measures { get; set; }
            public List<Set> sets { get; set; }
        }

        public class DataSpecification
        {
            public CubeSpecification cubeSpecification { get; set; }
            public ParetoSpecification paretoSpecification { get; set; }
            public VennSpecification vennSpecification { get; set; }
        }

        public class CategoryDisplay
        {
            public string displayType { get; set; }
            public int limit { get; set; }
            public bool autoAdjust { get; set; }
            public bool userAdjust { get; set; }
        }

        public class SecondaryCategoryDisplay
        {
            public string displayType { get; set; }
            public int limit { get; set; }
            public bool autoAdjust { get; set; }
            public bool userAdjust { get; set; }
        }

        public class DataLabels
        {
            public string showDataLabels { get; set; }
            public bool abbreviateCount { get; set; }
            public int labelStep { get; set; }
        }

        public class DashboardItemDetail
        {
            public int drilldownLevel { get; set; }
            public string description { get; set; }
            public string chartType { get; set; }
            public DataSpecification dataSpecification { get; set; }
            public string resolveTableName { get; set; }
            public bool allowCategoryDisplay { get; set; }
            public CategoryDisplay categoryDisplay { get; set; }
            public SecondaryCategoryDisplay secondaryCategoryDisplay { get; set; }
            public bool omitZeros { get; set; }
            public bool omitUnclassifiedRows { get; set; }
            public bool omitUnclassifiedColumns { get; set; }
            public string sortOrder { get; set; }
            public bool showUnderlyingData { get; set; }
            public string notes { get; set; }
            public bool showLegend { get; set; }
            public string legendPosition { get; set; }
            public bool abbreviateCount { get; set; }
            public int decimalPlaces { get; set; }
            public DataLabels dataLabels { get; set; }
        }

        public class DashboardItem
        {
            public string id { get; set; }
            public string title { get; set; }
            public List<Breakpoint> breakpoints { get; set; }
            public List<DashboardItemDetail> dashboardItemDetails { get; set; }
        }

        public class SelectorInfo
        {
            public string selectorType { get; set; }
            public string subType { get; set; }
            public string varCodeOrder { get; set; }
            public int numberOfCodes { get; set; }
            public int codeLength { get; set; }
            public int minimumVarCodeCount { get; set; }
            public int maximumVarCodeCount { get; set; }
            public DateTime minimumDate { get; set; }
            public DateTime maximumDate { get; set; }
            public string combinedFromVariableName { get; set; }
            public string unclassifiedCode { get; set; }
        }

        public class NumericInfo
        {
            public int minimum { get; set; }
            public int maximum { get; set; }
            public bool isCurrency { get; set; }
            public string currencyLocale { get; set; }
            public string currencySymbol { get; set; }
            public int decimalPlaces { get; set; }
        }

        public class TextInfo
        {
            public int maximumTextLength { get; set; }
        }

        public class ReferenceInfo
        {
        }

        public class Variable
        {
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string folderName { get; set; }
            public string tableName { get; set; }
            public bool isSelectable { get; set; }
            public bool isBrowsable { get; set; }
            public bool isExportable { get; set; }
            public bool isVirtual { get; set; }
            public SelectorInfo selectorInfo { get; set; }
            public NumericInfo numericInfo { get; set; }
            public TextInfo textInfo { get; set; }
            public ReferenceInfo referenceInfo { get; set; }
        }

        public class VarCodesLookup
        {
            public string code { get; set; }
            public string description { get; set; }
            public int count { get; set; }
        }

        public class VariablesLookup
        {
            public Variable variable { get; set; }
            public List<VarCodesLookup> varCodesLookup { get; set; }
        }

        public class AudiencesLookup
        {
            public int id { get; set; }
            public string title { get; set; }
            public string resolveTableName { get; set; }
            public int resolveTableNettCount { get; set; }
            public DateTime lastCountDate { get; set; }
        }

        public class FoldersLookup
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class DashboardsLookup
        {
            public int id { get; set; }
            public string title { get; set; }
        }

        public class BaseQueryLookup
        {
            public List<VariablesLookup> variablesLookup { get; set; }
            public List<AudiencesLookup> audiencesLookup { get; set; }
            public List<FoldersLookup> foldersLookup { get; set; }
            public List<DashboardsLookup> dashboardsLookup { get; set; }
        }

        public class Owner
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class LastUpdatedBy
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class Root
        {
            public string viewingUsername { get; set; }
            public bool sharedToMe { get; set; }
            public bool sharedByMe { get; set; }
            public BaseQuery baseQuery { get; set; }
            public List<DashboardItem> dashboardItems { get; set; }
            public BaseQueryLookup baseQueryLookup { get; set; }
            public int themeId { get; set; }
            public int logoId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string systemName { get; set; }
            public DateTime createdOn { get; set; }
            public Owner owner { get; set; }
            public DateTime lastUpdatedOn { get; set; }
            public LastUpdatedBy lastUpdatedBy { get; set; }
            public int lastUpdateId { get; set; }
            public int numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public int shareId { get; set; }
            public int numberOfHits { get; set; }
            public DateTime deletedOn { get; set; }
        }
    }
}