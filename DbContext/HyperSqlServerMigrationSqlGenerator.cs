using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    public class HyperSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
        {
            if (addPrimaryKeyOperation == null)
            {
                throw new ArgumentNullException("addPrimaryKeyOperation");
            }

            // turn off clustered index for all PKs (except for migration history)
            if ((!addPrimaryKeyOperation.Table.Contains("__MigrationHistory"))
                && (!addPrimaryKeyOperation.Table.Contains("AspNetUserClaims")))
            {
                addPrimaryKeyOperation.IsClustered = false;
            }


            base.Generate(addPrimaryKeyOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            if (createTableOperation == null)
            {
                throw new ArgumentNullException("createTableOperation");
            }

            // turn off clustered index for all PKs (except for migration history)
            if ((!createTableOperation.Name.Contains("__MigrationHistory"))
                && (!createTableOperation.Name.Contains("AspNetUserClaims")))
            {
                createTableOperation.PrimaryKey.IsClustered = false;
            }

            base.Generate(createTableOperation);
        }

        protected override void Generate(MoveTableOperation moveTableOperation)
        {
            if (moveTableOperation == null)
            {
                throw new ArgumentNullException("moveTableOperation");
            }

            // turn off clustered index for all PKs (except for migration history)
            if ((!moveTableOperation.CreateTableOperation.Name.Contains("__MigrationHistory"))
                && (!moveTableOperation.CreateTableOperation.Name.Contains("AspNetUserClaims")))
            {
                moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = false;
            }

            base.Generate(moveTableOperation);
        }

        protected override void Generate(CreateIndexOperation createIndexOperation)
        {
            if (createIndexOperation == null)
            {
                throw new ArgumentNullException("createIndexOperation");
            }

            //if (createIndexOperation.Table.Contains("AspNetRoles") && createIndexOperation.Name.Contains("RoleNameIndex"))
            //{
            //    createIndexOperation.Name = "IX_Host_Name";
            //}
            if (createIndexOperation.Table.Contains("AspNetUsers") && createIndexOperation.Name.Contains("UserNameIndex"))
            {
                createIndexOperation.Name = "IX_Host_Name";
            }

            base.Generate(createIndexOperation);
        }

        protected override string GuidColumnDefault
        {
            get
            {
                // always return newid() and not newsequentialid()
                return "newid()";
            }
        }
    }
}