using System;

namespace BatDemo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    public class OptionDto<T>(T id, string text)
    {
        /// <summary>
        /// 
        /// </summary>
        public T Id { get; set; } = id;
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; } = text;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    public class OptionNumberDto(int id, string text) : OptionDto<int>(id, text)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    public class OptionStrDto(string id, string text) : OptionDto<string>(id, text)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    public class OptionGuidDto(Guid id, string text) : OptionDto<Guid>(id, text)
    {
    }
}







