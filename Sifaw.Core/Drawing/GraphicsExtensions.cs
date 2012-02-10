using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Sifaw.Core.Drawing
{
	/// <summary>
	/// Exntensión de la clase Graphics.
	/// </summary>
	public static class GraphicsExtensions
	{
		#region Methods de trazado de rectángulos

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			float x,
			float y,
			float width,
			float height,
			float radius,
			RectangleRoundedEdgeFilter filter)
		{
			RectangleF rectangle = new RectangleF(x, y, width, height);

			using (GraphicsPath path = GenerateRoundedRectangle(graphics, rectangle, radius, filter))
			{
				SmoothingMode old = graphics.SmoothingMode;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.DrawPath(pen, path);
				graphics.SmoothingMode = old;
			}
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			float x,
			float y,
			float width,
			float height,
			float radius)
		{
			graphics.DrawRoundedRectangle(
				pen,
				x,
				y,
				width,
				height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			int x,
			int y,
			int width,
			int height,
			int radius,
			RectangleRoundedEdgeFilter filter)
		{
			graphics.DrawRoundedRectangle(
				pen,
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius),
				filter);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			int x,
			int y,
			int width,
			int height,
			int radius)
		{
			graphics.DrawRoundedRectangle(
				pen,
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius),
				RectangleRoundedEdgeFilter.All);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			Rectangle rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter)
		{
			graphics.DrawRoundedRectangle(
				pen,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				filter);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			Rectangle rectangle,
			int radius)
		{
			graphics.DrawRoundedRectangle(
				pen,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			RectangleF rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter)
		{
			graphics.DrawRoundedRectangle(
				pen,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				filter);
		}

		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			RectangleF rectangle,
			int radius)
		{
			graphics.DrawRoundedRectangle(
				pen,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		#endregion

		#region Methods de relleno de rectángulos

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			float x,
			float y,
			float width,
			float height,
			float radius,
			RectangleRoundedEdgeFilter filter)
		{
			RectangleF rectangle = new RectangleF(x, y, width, height);

			using (GraphicsPath path = GenerateRoundedRectangle(graphics, rectangle, radius, filter))
			{
				SmoothingMode old = graphics.SmoothingMode;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.FillPath(brush, path);
				graphics.SmoothingMode = old;
			}
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			float x,
			float y,
			float width,
			float height,
			float radius)
		{
			graphics.FillRoundedRectangle(
				brush,
				x,
				y,
				width,
				height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			int x,
			int y,
			int width,
			int height,
			int radius)
		{
			graphics.FillRoundedRectangle(
				brush,
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius),
				RectangleRoundedEdgeFilter.All);
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			Rectangle rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter)
		{
			graphics.FillRoundedRectangle(
				brush,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				filter);
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			Rectangle rectangle,
			int radius)
		{
			graphics.FillRoundedRectangle(
				brush,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			RectangleF rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter)
		{
			graphics.FillRoundedRectangle(
				brush,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				filter);
		}

		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			RectangleF rectangle,
			int radius)
		{
			graphics.FillRoundedRectangle(
				brush,
				rectangle.X,
				rectangle.Y,
				rectangle.Width,
				rectangle.Height,
				radius,
				RectangleRoundedEdgeFilter.All);
		}

		#endregion

		#region Fondos con degradado predefinidos

		/// <summary>
		/// Dibuja un fondo degradado con reflejo.
		/// </summary>
		public static void DrawCrystalBackground(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter,
			Color color,
			int alpha)
		{
			graphics.DrawCrystalBackground(
				rectangle,
				radius,
				filter,
				Color.White,
				color,
				alpha);
		}

		/// <summary>
		/// Dibuja un fondo degradado con reflejo.
		/// </summary>
		public static void DrawCrystalBackground(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter,
			Color color1,
			Color color2,
			int alpha)
		{
			HSLColor hslReflex1 = HSLColor.FromRGB(color1);
			hslReflex1.Luminance -= 0.05f;

			HSLColor hslReflex2 = HSLColor.FromRGB(color2);
			hslReflex2.Luminance -= 0.01f;

			graphics.DrawCrystalBackground(
				rectangle,
				radius,
				filter,
				color1,
				color2,
				hslReflex1.RGB,
				hslReflex2.RGB,
				alpha);
		}

		/// <summary>
		/// Dibuja un fondo degradado con reflejo.
		/// </summary>
		public static void DrawCrystalBackground(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RectangleRoundedEdgeFilter filter,
			Color color1,
			Color color2,
			Color reflexColor1,
			Color reflexColor2,
			int alpha)
		{
			Rectangle bounds = rectangle;

			if ((bounds.Width == 0) || (bounds.Height == 0))
				return;

			using (LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.FromArgb(alpha, color1), Color.FromArgb(alpha, color2), LinearGradientMode.Vertical))
			{
				graphics.FillRoundedRectangle(brush, bounds, radius, filter);
			}

			// Dibujamos el reflejo del fondo (mitad inferior del bounds)
			Rectangle boundsReflejo = bounds;
			boundsReflejo.Y += bounds.Height / 2;
			boundsReflejo.Height /= 2;

			using (LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.FromArgb(Math.Min(alpha, 128), reflexColor1), Color.FromArgb(Math.Min(alpha, 128), reflexColor2), LinearGradientMode.Vertical))
			{
				graphics.FillRoundedRectangle(brush, boundsReflejo, radius, filter);
			}
		}

		#endregion

		#region Methods privados

		/// <summary>
		/// Devuelve el objeto GraphicsPath con la definición del rectángulo con las esquinas en forma de arco.
		/// </summary>
		private static GraphicsPath GenerateRoundedRectangle(
				this Graphics graphics,
				RectangleF rectangle,
				float radius,
				RectangleRoundedEdgeFilter filter)
		{
			if (radius <= 0.0F || filter == RectangleRoundedEdgeFilter.None)
			{
				GraphicsPath path = new GraphicsPath();
				path.StartFigure();
				path.AddRectangle(rectangle);
				path.CloseFigure();
				return path;
			}
			else
			{
				if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
					return GenerateCapsule(graphics, rectangle);

				GraphicsPath path = new GraphicsPath();
				path.StartFigure();

				float diameter = radius * 2.0F;
				SizeF sizeF = new SizeF(diameter, diameter);
				RectangleF arc = new RectangleF(rectangle.Location, sizeF);

				if ((RectangleRoundedEdgeFilter.TopLeft & filter) == RectangleRoundedEdgeFilter.TopLeft)
					path.AddArc(arc, 180, 90);
				else
				{
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
				}

				arc.X = rectangle.Right - diameter;

				if ((RectangleRoundedEdgeFilter.TopRight & filter) == RectangleRoundedEdgeFilter.TopRight)
					path.AddArc(arc, 270, 90);
				else
				{
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
					path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
				}

				arc.Y = rectangle.Bottom - diameter;

				if ((RectangleRoundedEdgeFilter.BottomRight & filter) == RectangleRoundedEdgeFilter.BottomRight)
					path.AddArc(arc, 0, 90);
				else
				{
					path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
				}

				arc.X = rectangle.Left;

				if ((RectangleRoundedEdgeFilter.BottomLeft & filter) == RectangleRoundedEdgeFilter.BottomLeft)
					path.AddArc(arc, 90, 90);
				else
				{
					path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
				}

				path.CloseFigure();
				return path;
			}
		}

		/// <summary>
		/// Devuelve el objeto GraphicsPath con la definición de una elipse para el rectángulo especificado.
		/// </summary>
		private static GraphicsPath GenerateCapsule(this Graphics graphics, RectangleF rectangle)
		{
			float diameter;
			RectangleF arc;
			GraphicsPath path = new GraphicsPath();

			try
			{
				if (rectangle.Width > rectangle.Height)
				{
					diameter = rectangle.Height;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 90, 180);
					arc.X = rectangle.Right - diameter;
					path.AddArc(arc, 270, 180);
				}
				else if (rectangle.Width < rectangle.Height)
				{
					diameter = rectangle.Width;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 180, 180);
					arc.Y = rectangle.Bottom - diameter;
					path.AddArc(arc, 0, 180);
				}
				else path.AddEllipse(rectangle);
			}
			catch { path.AddEllipse(rectangle); }
			finally { path.CloseFigure(); }
			return path;
		}

		#endregion
	}

	#region Miscelanea

	[Flags()]
	public enum RectangleRoundedEdgeFilter
	{
		None = 0,
		TopLeft = 1,
		TopRight = 2,
		BottomLeft = 4,
		BottomRight = 8,
		TopLeftAndRight = TopLeft | TopRight,
		BottonLeftAndRight = BottomLeft | BottomRight,
		All = TopLeftAndRight | BottonLeftAndRight
	}

	#endregion
}
