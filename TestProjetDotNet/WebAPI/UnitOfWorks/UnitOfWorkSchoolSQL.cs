using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.UnitOfWorks
{
    public class UnitOfWorkSchoolSQL : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;

        private BaseRepositorySQL<Student> _studentssRepository;
        // private BaseRepositorySQL<Section> _sectionssRepository;


        public UnitOfWorkSchoolSQL(SchoolContext context)
        {
            this._context = context;
            this._studentssRepository = new BaseRepositorySQL<Student>(context);
            // this._sectionssRepository = new BaseRepositorySQL<Section>(context);
        }

        public IRepository<Student> StudentsRepository
        {
            get { return this._studentssRepository; }
        }

        // public IRepository<Section> SectionsRepository { get { return this._sectionssRepository; } }
    }
}
