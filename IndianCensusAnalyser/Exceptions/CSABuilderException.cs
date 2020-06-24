//-----------------------------------------------------------------------
// <copyright file="CSABuilderException.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace IndianCensusAnalyser.Exceptions
{
    using System;

    /// <summary>
    /// CSABuilderException class
    /// </summary>
    public class CSABuilderException:Exception
    {
        /// <summary>
        /// enum exception type
        /// </summary>
        public enum ExceptionType
        {
            No_SuchFile_Exception,
            Type_Incorrect,
            File_Delimeter_Incorrect,
            Header_Incorrrect
        }

        /// <summary>
        /// Exception type
        /// </summary>
        public ExceptionType EType;

        /// <summary>
        /// Constructor for exception type 
        /// </summary>
        /// <param name="EType">EType parameter</param>
        /// <param name="message">message parameter</param>
        public CSABuilderException(ExceptionType EType, string message) : base(message)
        {
            this.EType = EType;
        }
    }
}
