using System;
using System.ComponentModel.DataAnnotations;

namespace Aprimo.Opti.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AprimoTransformAttribute : ScaffoldColumnAttribute
    {
        public AprimoTransformAttribute()
            : base(false)
        {
        }

        public AprimoTransformAttribute(
            string auto,
            string backgroundColor,
            string blur,
            string brightness,
            string canvas,
            string contrast,
            string crop,
            string disable,
            string dpr,
            string enable,
            string fit,
            string format,
            string frame,
            string height,
            string level,
            string optimize,
            string orient,
            string pad,
            string precrop,
            string profile,
            string quality,
            string resizefilter,
            string saturation,
            string sharpen,
            string trim,
            string width)
            : this()
        {
            Auto = auto;
            BackgroundColor = backgroundColor;
            Blur = blur;
            Brightness = brightness;
            Canvas = canvas;
            Contrast = contrast;
            Crop = crop;
            Disable = disable;
            DPR = dpr;
            Enable = enable;
            Fit = fit;
            Format = format;
            Frame = frame;
            Height = height;
            Level = level;
            Optimize = optimize;
            Orient = orient;
            Pad = pad;
            Precrop = precrop;
            Profile = profile;
            Quality = quality;
            ResizeFilter = resizefilter;
            Saturation = saturation;
            Sharpen = sharpen;
            Trim = trim;
            Width = width;
        }

        /// <summary>
        /// Enables optimizations based on content negotiation.
        /// The only negotiated optimization currently available is for WebP, an image compression format with limited browser support.
        /// </summary>
        public string Auto { get; set; }

        /// <summary>
        /// Sets the background color of the image.
        /// The bg-color parameter sets the background color of an image to use when applying padding or when replacing transparent pixels.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Applies a Gaussian blur filter to the image.
        /// </summary>
        public string Blur { get; set; }

        /// <summary>
        /// The brightness parameter increases or decreases the amount of perceived light an image radiates or reflects.
        /// </summary>
        public string Brightness { get; set; }

        /// <summary>
        /// Change the size of the image canvas.
        /// Sets the size of the image canvas, without changing the size of the image itself, which has the effect of adding space around the image.
        /// https://developer.fastly.com/reference/io/canvas/
        /// </summary>
        public string Canvas { get; set; }

        /// <summary>
        /// The contrast parameter increases or decreases the difference between the darkest and lightest tones in an image.
        /// </summary>
        public string Contrast { get; set; }

        /// <summary>
        /// Removes pixels from an image.
        /// When specifying a crop parameter, the value starts with the desired width and height, either as measurements of pixels, separated with a comma, or as a ratio, separated with a colon(for example, crop= 4:3 or crop = 640,480 or crop = 0.8,0.4).
        /// </summary>
        public string Crop { get; set; }

        /// <summary>
        /// Disables features that are enabled by default.
        /// example: disable=upscale
        /// </summary>
        public string Disable { get; set; }

        /// <summary>
        /// Device pixel ratio.
        /// The dpr parameter provides a means to multiply image dimensions in order to translate logical pixels(also 'CSS pixels') into physical pixels.The device pixel ratio is therefore the ratio between physical pixels and logical pixels.
        /// </summary>
        public string DPR { get; set; }

        /// <summary>
        /// Enables features that are disabled by default.
        /// example: enable=upscale
        /// </summary>
        public string Enable { get; set; }

        /// <summary>
        /// The fit parameter controls how the image will be constrained within the provided size (width and height) values, in order to maintain the correct proportions.
        /// </summary>
        public string Fit { get; set; }

        /// <summary>
        /// Specifies the desired output encoding for the image.
        /// The format parameter enables the source image to be converted(a.k.a., "transcoded") from one encoded format to another.This is useful when the source image has been saved in a sub-optimal file format that hinders performance.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Extracts the first frame from an animated image sequence.
        /// </summary>
        public string Frame { get; set; }

        /// <summary>
        /// The desired height of the output image.
        /// The height parameter enables dynamic height resizing based on pixels and percent values.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// When converting animated GIFs to the MP4 format and when used in conjunction with the profile parameter, the level parameter specifies a set of constraints indicating a degree of required decoder performance for a profile.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// The optimize parameter automatically applies optimal quality compression to produce an output image with as much visual fidelity as possible, while minimizing the file size.
        /// </summary>
        public string Optimize { get; set; }

        /// <summary>
        /// How the image will be orientated.
        /// The orient parameter controls the cardinal orientation of the image.
        /// </summary>
        public string Orient { get; set; }

        /// <summary>
        /// Add pixels to the edge of an image.
        /// </summary>
        public string Pad { get; set; }

        /// <summary>
        /// Removes pixels from an image before any other transformations occur.
        /// Identical to crop except that precrop is performed before any other transformations.
        /// </summary>
        public string Precrop { get; set; }

        /// <summary>
        /// When converting animated GIFs to MP4 format and when used in conjunction with the level parameter, the profile parameter controls which features the video encoder can use based on a target class of application for decoding the specific video bitstream.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Output image quality for lossy file formats.
        /// The quality parameter enables control over the compression level for lossy file-formatted images.
        /// </summary>
        public string Quality { get; set; }

        /// <summary>
        /// The resize-filter parameter enables control over the resizing filter used to generate a new image with a higher or lower number of pixels.
        /// </summary>
        public string ResizeFilter { get; set; }

        /// <summary>
        /// Saturation of the output image.
        /// The saturation parameter increases or decreases the intensity of the colors in an image.
        /// </summary>
        public string Saturation { get; set; }

        /// <summary>
        /// Sharpness of the output image.
        /// The sharpen parameter increases the definition of the edges of objects in an image.
        /// </summary>
        public string Sharpen { get; set; }

        /// <summary>
        /// Remove pixels from the edge of an image.
        /// The trim parameter removes pixels from the edge of an image by pixel or percentage value.This can be useful for removing whitespace and borders that appear on a source image.
        /// </summary>
        public string Trim { get; set; }

        /// <summary>
        /// The desired width of the output image.
        /// The width parameter enables dynamic width resizing based on pixels and percent values.
        /// </summary>
        public string Width { get; set; }
    }
}