using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components 
{
    public partial class WAAvatar : WAComponentBase
    {
        #region Parameters


        /// <summary>
        /// The name of the default icon to use when no image or initials are present. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? IconName { get; set; }

        /// <summary>
        /// The default icon to use when no image or initials are present. Alternatively, use the IconName parameter to specify an icon by name.
        /// </summary>
        [Parameter]
        public Icon? Icon { get; set; }

        /// <summary>
        /// The image source to use for the avatar.
        /// </summary>
        [Parameter]
        public string? ImageSource { get; set; }
        
        /// <summary>
        /// Set the name to use as initials if an image is not provided.
        /// The initials will use first letter of first name and last name (if provided).
        /// The name also provides a label to use to describe the avatar to assistive devices.
        /// </summary>
        [Parameter]
        public string? Name { get; set; }

        /// <summary>
        /// Indicates how the browser should load the image.
        /// </summary>
        [Parameter]
        public bool LazyLoading { get; set; } = false;


        /// <summary>
        /// The shape of the avatar.
        /// </summary>
        [Parameter]
        public AvatarShape Shape { get; set; } = AvatarShape.Circle;

        #endregion

        #region Computed Properties
        string? Initials
        {
            get
            {
                if (String.IsNullOrEmpty(Name)) return String.Empty;
                if (!String.IsNullOrEmpty(IconName) || Icon is not null) return String.Empty;

                string[] names = Name.Split(" ");
                if (names.Length == 0) return String.Empty;
                if (names.Length == 1) return names[0].First().ToString();
                return (names[0].First().ToString() + names.Last().First().ToString());
            }
        }

        string Label
        {
            get
            {
                if (string.IsNullOrEmpty(Name)) return "Avatar";
                return Name;
            }
        }

        string Loading
        {
            get
            {
                return LazyLoading ? "lazy" : "eager";
            }
        }

        string ShapeString
        {
            get
            {
                return Shape switch
                {
                    AvatarShape.Circle => "circle",
                    AvatarShape.Square => "square",
                    AvatarShape.Rounded => "rounded",
                    _ => "circle"
                };
            }
        }
        #endregion

     }
}
