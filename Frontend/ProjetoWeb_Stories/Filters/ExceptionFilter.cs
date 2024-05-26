using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ProjetoWeb_Stories.Models;

namespace ProjetoWeb_Stories.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var error = new ErrorModel
			(
				500,
				context.Exception.Message,
				context.Exception.StackTrace?.ToString()
			);
			var modelMetadata = new EmptyModelMetadataProvider();

			context.Result = new ViewResult
			{
				ViewName = "~/Views/Shared/CustomError.cshtml",
				ViewData = new ViewDataDictionary(modelMetadata, context.ModelState)
				{
					Model = error
				}

			};


		}
	}
}
