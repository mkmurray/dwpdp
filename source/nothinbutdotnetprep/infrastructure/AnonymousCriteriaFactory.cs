namespace nothinbutdotnetprep.infrastructure
{
    public static class AnonymousCriteriaFactory<ItemToFilter>
    {
        public static AnonymousCriteria<ItemToFilter> Create(Matches<ItemToFilter> condition)
        {
            return new AnonymousCriteria<ItemToFilter>(condition);
        }
    }
}