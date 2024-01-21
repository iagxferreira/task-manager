namespace TaskManager.API.Repositories.Interfaces
{
    public interface IBaseRepository<Model, Domain, Identity>
    {
        public Task<Model> Create(Domain domain);
        public Task<List<Model>> Read();
        public Task<Model?> ReadById(Identity id);
        public Task<Model> Update(Identity id, Domain domain);
        public Task<Model> Delete(Identity id);
    }
}
