using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models.Audiences
{
    public class CreateAudience
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

        public class ExcludeQuery
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class IncludeQuery
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class BodyQuery
        {
            public Selection selection { get; set; }
            public string todayAt { get; set; }
        }

        public class SelectionModifiers
        {
            public Limits limits { get; set; }
            public TopN topN { get; set; }
            public NPer nPer { get; set; }
            public Rfv rfv { get; set; }
        }

        public class Root
        {
            public string title { get; set; }
            public string description { get; set; }
            public ExcludeQuery excludeQuery { get; set; }
            public IncludeQuery includeQuery { get; set; }
            public BodyQuery bodyQuery { get; set; }
            public SelectionModifiers selectionModifiers { get; set; }
            public string briefText { get; set; }
            public string campaignId { get; set; }
            public string systemName { get; set; }
        }


    }
}
