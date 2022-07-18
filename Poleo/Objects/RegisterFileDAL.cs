using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;

namespace Poleo.Objects
{
    public class RegisterFileDAL
    {
        ISqlMapper mapper;
        public void InsertRegisterFile(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertRegisterFile", param);
        }
        public void InsertUpLoadedFiles(Files param)
        {
            mapper = Mapper.Instance();
            mapper.Insert("InsertUpLoadedFiles", param);
        }
        public IList<RegisterFile> SelectRegisterFile(RegisterFile param)
        {
            mapper = Mapper.Instance();
            return mapper.QueryForList<RegisterFile>("SelectRegisterFile", param);
        }
        public void UpDateRegisterFileATR(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileATR", param);
        }
        public void UpDateRegisterFileCKY(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileCKY", param);

        }
        public  void  UpDateRegisterFileDYS(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileDYS", param);
        }
        public void UpDateRegisterFileINV(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileINV", param);
        }
        public  void UpDateRegisterFileIPR(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileIPR",param);
        }
        public void UpDateRegisterFileORD(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileORD", param);
        }
        public void UpDateRegisterFilePRS(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFilePRS", param);
        }
        public void UpDateRegisterFileOC2(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileOC2", param);
        }
        public void UpDateRegisterFileIPD(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileIPD", param);
        }
        public void UpDateRegisterFileODT(RegisterFile param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileODT", param);
        }

        //Added by Hector Sanchez M. 20160518
        public void UpDateRegisterFileOR2(RegisterFile Param)
        {
            mapper = Mapper.Instance();
            mapper.Update("UpDateRegisterFileOR2", Param);
        }
    }
}