using System;
using System.Collections.Generic;
using System.Text;

namespace APIStuff.Models
{
    public class CompositionDetails
    {
        public class Size
        {
            public decimal? width { get; set; }
            public decimal? height { get; set; }
        }

        public class DashboardItem
        {
            public string variableName { get; set; }
            public Size size { get; set; }
            public string chartType { get; set; }
            public bool omitZeros { get; set; }
            public string sortOrder { get; set; }
            public string description { get; set; }
        }

        public class GridItem
        {
            public string variableName { get; set; }
            public string detail { get; set; }
            public string unclassifiedFormat { get; set; }
            public string description { get; set; }
        }

        public class CheckCompositionDefinition
        {
            public List<DashboardItem> dashboardItems { get; set; }
            public List<GridItem> gridItems { get; set; }
        }

        public class Output
        {
            public string format { get; set; }
            public string delimiter { get; set; }
            public string alphaEncloser { get; set; }
            public string numericEncloser { get; set; }
            public string authorisationCode { get; set; }
            public string exportExtraName { get; set; }
        }

        public class ExportCompositionDefinition
        {
            public Output output { get; set; }
            public List<GridItem> gridItems { get; set; }
        }

        public class SelectorInfo
        {
            public string selectorType { get; set; }
            public string subType { get; set; }
            public string varCodeOrder { get; set; }
            public decimal? numberOfCodes { get; set; }
            public decimal? codeLength { get; set; }
            public decimal? minimumVarCodeCount { get; set; }
            public decimal? maximumVarCodeCount { get; set; }
            public DateTime? minimumDate { get; set; }
            public DateTime? maximumDate { get; set; }
            public string combinedFromVariableName { get; set; }
            public string unclassifiedCode { get; set; }
        }

        public class NumericInfo
        {
            public decimal? minimum { get; set; }
            public decimal? maximum { get; set; }
            public bool isCurrency { get; set; }
            public string currencyLocale { get; set; }
            public string currencySymbol { get; set; }
            public decimal? decimalPlaces { get; set; }
        }

        public class TextInfo
        {
            public decimal? maximumTextLength { get; set; }
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
            public decimal? count { get; set; }
        }

        public class VariablesLookup
        {
            public Variable variable { get; set; }
            public List<VarCodesLookup> varCodesLookup { get; set; }
        }

        public class AudiencesLookup
        {
            public decimal? id { get; set; }
            public string title { get; set; }
            public string resolveTableName { get; set; }
            public decimal? resolveTableNettCount { get; set; }
            public DateTime? lastCountDate { get; set; }
        }

        public class FoldersLookup
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class DashboardsLookup
        {
            public decimal? id { get; set; }
            public string title { get; set; }
        }

        public class CompositionsLookup
        {
            public List<VariablesLookup> variablesLookup { get; set; }
            public List<AudiencesLookup> audiencesLookup { get; set; }
            public List<FoldersLookup> foldersLookup { get; set; }
            public List<DashboardsLookup> dashboardsLookup { get; set; }
        }

        public class Owner
        {
            public decimal? id { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string emailAddress { get; set; }
        }

        public class Root
        {
            public CheckCompositionDefinition checkCompositionDefinition { get; set; }
            public ExportCompositionDefinition exportCompositionDefinition { get; set; }
            public CompositionsLookup compositionsLookup { get; set; }
            public decimal? id { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string systemName { get; set; }
            public Owner owner { get; set; }
            public decimal? numberOfUsersSharedWith { get; set; }
            public bool sharedToAll { get; set; }
            public decimal? shareId { get; set; }
        }
    }
}
