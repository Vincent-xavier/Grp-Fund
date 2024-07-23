namespace Fund_API.Framework
{
    public class StoredProc
    {
        public class Login
        {
            public const string UserAuthenticate = "[Users].[UserAuthentication]";
            public const string ChangePassword = "[dbo].[ChangePassword]";
        }
        public class UserDetails
        {
            public const string GetUserDetails = "get_user_details";
            public const string SaveUserDetails = "save_user_details1";
            public const string DeleteUserDetails = "delete_user_details1";
        }

        public class UserRole
        {
            public const string SaveUserRole = "save_user_role";
            public const string DeleteUserRole = "delete_user_role";
        }

        public class SupportData
        {
            public const string GetFieldName = "public.get_field_name";
            public const string GetFieldName1 = "call public.get_field_name ();";
            public const string SaveFieldData = "public.save_field_data";
            public const string DeleteFieldData = "public.delete_field_data";
            public const string UpdateFieldStatus = "public.update_field_data_status";
        }
    }

    public class SQLQueryText
    {
        public class UserDetails
        {
            public const string GetUserDetails = "SELECT u.user_id,u.first_name,u.last_name,u.dob,u.contact_no,u.address1,u.address2,u.city,s.statename,c.countryname,u.user_name,u.password,u.user_image,u.role_id,u.created_date, u.modified_date,u.isdelete,u.isactive,u.email,customerid,isadmin  FROM  public.user_details u LEFT JOIN    public.countries c ON c.id = u.country LEFT JOIN    public.states s ON s.id = u.state WHERE COALESCE(u.customerid,0)= 0;";
            public const string GetUserDetailById = @"SELECT u.user_id,u.first_name,u.last_name,u.dob,u.contact_no,u.address1,u.address2,u.city,u.State,u.country,u.user_name,u.password,u.user_image,u.role_id,u.created_date, u.modified_date,u.isdelete,u.isactive,u.email,u.Primary_site,u.Secondary_sites,customerid,isadmin  FROM  public.user_details u WHERE u.user_id = @userId;";
            public const string SaveUserDetails = @"INSERT INTO public.user_details (first_name, last_name, dob, contact_no, address1, address2, city, state, country, user_name, ""password"", user_image, role_id, created_date, modified_date, isdelete, isactive, email,primary_site,secondary_sites,customerid,isadmin) VALUES (@first_name, @last_name, @dob, @contact_no, @address1, @address2, @city, @state, @country, @user_name, @password, @user_image, @role_id, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @isdelete, @isactive, @email,@Primary_site,@Secondary_sites,@CustomerId,@IsAdmin) RETURNING user_id;";
            public const string UpdateUserDetails = @"UPDATE public.user_details SET  first_name = @first_name, last_name = @last_name,dob = @dob, contact_no = @contact_no,address1 = @address1,address2 = @address2,city = @city,state = @state,country = @country, user_name = @user_name,""password"" = @password,user_image = @user_image,role_id = @role_id,modified_date = CURRENT_TIMESTAMP,isdelete = @isdelete,isactive = @isactive,email = @email,primary_site=@Primary_site,secondary_sites=@Secondary_sites,customerid=@CustomerId,isadmin=@IsAdmin WHERE user_id = @user_id RETURNING user_id;";
            public const string DeleteUserDetailById = @"UPDATE public.user_details SET isdelete = True WHERE user_id = @userId  ;";

        }
        public class SupportTicket
        {
            public const string GetSupportTicket = "SELECT ticket_id, customer_id, subject, description, status, priority, created_at, updated_at, isdelete\r\n\tFROM public.support_tickets WHERE isDelete=false;";
            public const string GetSupportTicketById = @"SELECT ticket_id, customer_id, subject, description, status, priority, created_at, updated_at, isdelete	FROM public.support_tickets WHERE ticket_id = @ticket_id;";
            public const string SaveSupportTicket = @"INSERT INTO public.user_details (user_id, first_name, last_name, dob, contact_no, address1, address2, city, state, country, user_name, ""password"", user_image, role_id, created_date, modified_date, isdelete, isactive, email) VALUES (@user_id, @first_name, @last_name, @dob, @contact_no, @address1, @address2, @city, @state, @country, @user_name, @password, @user_image, @role_id, @created_date, @modified_date, @isdelete, @isactive, @email);";
            public const string UpdateSupportTicket = @"UPDATE public.user_details SET  first_name = @first_name, last_name = @last_name,dob = @dob, contact_no = @contact_no,address1 = @address1,address2 = @address2,city = @city,state = @state,country = @country, user_name = @user_name,""password"" = @password,user_image = @user_image,role_id = @role_id,created_date = @created_date,modified_date = @modified_date,isdelete = @isdelete,isactive = @isactive,email = @email WHERE user_id = @user_id;";
            public const string DeleteSupportTicketById = @"UPDATE public.support_tickets SET isDelete=true  updated_at = CURRENT_TIMESTAMP WHERE ticket_id = @ticket_id; ;";

        }
        public class UserRole
        {
            public const string GetUserRole = "select role_id as RoleId,role_name as RoleName,role_type as Roletype,description as Description from user_role where is_deleted = 'false'\r\n;";
            public const string GetUserRoleById = "select  role_id as RoleId,role_name as RoleName,Description from public.user_role where role_id = @RoleId and is_deleted = false";
            public const string DeleteUserRoleById = "update public.user_role set is_deleted = true,modified_date = CURRENT_DATE where role_id = @RoleId";
            public const string SaveUserRoles = "insert into public.user_role(role_name,description,created_date) values (@RoleName, @Description,CURRENT_DATE) RETURNING role_id;";
            public const string UpdateUserRoles = "insert into public.user_role(role_name,description,created_date) values (@RoleName, @Description,CURRENT_DATE) RETURNING role_id;";
        }
        public class UserRights
        {
            public const string LoadUserDetails = "SELECT user_id, CONCAT(first_name, ' ', last_name) AS fullname FROM public.user_details where role_id = @RoleId and isactive = true and isdelete = false;";
            public const string ListUserRights = "SELECT MF.featureid ,MF.parentid ,MF.module ,submodule ,itemdescription ,Coalesce(MR.accessright,0) as accessright,accessLevel  FROM public.modulefeatures MF left join public.modulerights MR on MF.featureid = MR.featureid and roleid=2 where showinuserrights=1 order by mf.displayorder;";
        }
        public class SupportData
        {
            public const string GetFieldName = "select fieldid,name from field_name where not isdelete order by fieldid asc;";
            public const string GetFieldName1 = "SELECT * FROM get_supportdata();";
            public const string GetFieldDataById = "select dataid,fieldid,name,COALESCE(description,'') as description  from public.field_data where dataid=@dataid;";
            public const string GetFieldDataEditById = "select dataid,fieldid,name,COALESCE(description,'') as description,isactive as active,case when isactive='1' then 'Active' Else 'InActive' END as isactive ,TO_CHAR(createdate, 'DD/MM/YYYY') AS createdate from public.field_data where fieldid=@fieldid  and not isdelete order by dataid asc;";
            public const string InsertFieldData = "Insert into public.field_data(fieldid,name,description) Values(@fieldid,@name,@description) RETURNING dataid;";
            public const string UpdateFieldData = "update public.field_data set name=@name,description=@description,modifieddate=CURRENT_DATE Where dataid=@dataid RETURNING dataid;";
            public const string DeleteFieldData = "Update public.field_data set isdelete=true where dataid=@dataid RETURNING dataid;";
            public const string UpdateFieldStatus = "Update public.field_data set isactive=@active where dataid=@dataid RETURNING dataid;";
            public const string InsertExist = "select count(*) from public.field_data where name=@name and isdelete=false and fieldid=@fieldid;";
            public const string UpdateExist = "select count(*) from public.field_data where name=@name and isdelete=false and fieldid=@fieldid and dataid<>@dataid;";
        }
        public class ContactUs
        {
            public const string GetWebSite = "SELECT w.id, w.name, COUNT(wr.id) AS request_count FROM website w LEFT JOIN website_requests wr ON w.id = wr.website_id and wr.status=1 WHERE w.status = 1 GROUP BY w.id, w.name ORDER BY w.id ASC;";
            public const string GetWebSiteEditById = "select id,(firstname|| ' ' || lastname) as name,phone_number ,email,COALESCE(description,'') as description,case when status =1 then 'Requested' Else case when status =2 then 'Trial' else 'Active' end  END as status, status as currentStatus ,TO_CHAR(createdon_date, 'DD/MM/YYYY') AS createdon_date,reference_id,CASE WHEN request_for = True then 'Demo' ELSE CASE WHEN request_for = false THEN 'Contact' ELSE '' END END as request_for,organization_name  from website_requests  where is_delete=false and website_id=@website_id";
            public const string GetWebSiteRequestEditById = "select id,firstname,lastname,phone_number ,email,COALESCE(description,'') as description,case when status =1 then 'Requested' Else case when status =2 then 'Trial' else 'Active' end  END as status ,TO_CHAR(createdon_date, 'DD/MM/YYYY') AS createdon_date from website_requests  where is_delete=false and id=@Id";
        }
        public class Common
        {
            public const string GetWebSite = "SELECT id, name FROM website WHERE status = 1 ORDER BY id ASC;";
            public const string GetSelectedWebsites = "SELECT id, name FROM website WHERE id  = ANY (string_to_array(@Ids, ',')::int[])  and status = 1 ORDER BY id ASC;";

        }
        public class DocumentLibrary
        {
            public const string SaveDocumentLibrary = @"INSERT INTO public.document_library (title, postdate, lengthofvideo, partofseries, seriesname, sequenceinseries, filetype, filename, filepath, uniquefilename) VALUES (@Title, @PostDate, @LengthofVideo, @IsThisPartOfSeries, @SeriesName, @SequenceInSeries, @FileType, @FileName, @FilePath, @UniqueFileName) RETURNING id;";
            public const string GetDocumentLibrary = "SELECT id,title,TO_CHAR(postdate::date, 'DD/MM/YYYY') AS postdate,lengthofvideo, partofseries,seriesname, sequenceinseries,CASE WHEN filetype = 1 THEN 'Video'WHEN filetype = 2 THEN 'Microsoft Powerpoint' ELSE 'Video' END AS filetypename, filename,filepath,uniquefilename FROM public.document_library WHERE isdelete = false;";
            public const string GetDocumentLibraryById = "SELECT id,title, postdate, lengthofvideo, partofseries AS IsThisPartOfSeries, seriesname, sequenceinseries,filetype, filename, filepath, uniquefilename,isdelete, isactive FROM public.document_library WHERE id = @Id";
            public const string UpdateDocumentLibrary = @"UPDATE public.document_library SET title = @Title, postdate = @PostDate,lengthofvideo = @LengthOfVideo,partofseries = @IsThisPartOfSeries, seriesname = @SeriesName,sequenceinseries = @SequenceInSeries, filetype = @FileType,filename = @FileName,filepath = @FilePath,UniqueFileName = @UniqueFileName WHERE id = @Id RETURNING id;";
            public const string DeleteDocumentLibrary = "update public.document_library set isdelete = true where id = @Id RETURNING id;";
        }
    }

}