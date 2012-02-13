/*
 * Sifaw.Core.Drawing
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Sifaw.Core.Drawing
{
	/// <summary>
	/// Exntensión de la clase <see cref="Graphics"/>.
	/// </summary>
	public static class GraphicsExtensions
	{
		#region Methods de trazado de rectángulos

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			float x,
			float y,
			float width,
			float height,
			float radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius),
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			int x,
			int y,
			int width,
			int height,
			int radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			Rectangle rectangle,
			int radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="rectangle"><see cref="RectangleF"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void DrawRoundedRectangle(
			this Graphics graphics,
			Pen pen,
			RectangleF rectangle,
			int radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Dibuja un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="pen"><see cref="Pen"/> usado para dibujar el rectángulo.</param>
		/// <param name="rectangle"><see cref="RectangleF"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		#endregion

		#region Methods de relleno de rectángulos

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			float x,
			float y,
			float width,
			float height,
			float radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			int x,
			int y,
			int width,
			int height,
			int radius,
			RoundedEdgeFilters filter)
		{
			graphics.FillRoundedRectangle(
				brush,
				Convert.ToSingle(x),
				Convert.ToSingle(y),
				Convert.ToSingle(width),
				Convert.ToSingle(height),
				Convert.ToSingle(radius),
				filter);
		}

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="x">Coordenada x del rectángulo.</param>
		/// <param name="y">Coordenada y del rectángulo.</param>
		/// <param name="width">Ancho del rectángulo.</param>
		/// <param name="height">Alto del rectángulo.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			Rectangle rectangle,
			int radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="rectangle"><see cref="RectangleF"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		public static void FillRoundedRectangle(
			this Graphics graphics,
			Brush brush,
			RectangleF rectangle,
			int radius,
			RoundedEdgeFilters filter)
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

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes redondeados.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="brush"><see cref="Brush"/> usado para rellenar el rectángulo.</param>
		/// <param name="rectangle"><see cref="RectangleF"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
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
				RoundedEdgeFilters.All);
		}

		#endregion

		#region Fondos con degradado predefinidos

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes con un fondo degradado con reflejo.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		/// <param name="color">Color predominante del degradado. El degradado parte del blanco como color base.</param>
		/// <param name="alpha">Especifíca el nivel de transparencia.</param>
		public static void FillCrystalRoundedRectangle(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RoundedEdgeFilters filter,
			Color color,
			int alpha)
		{
			graphics.FillCrystalRoundedRectangle(
				rectangle,
				radius,
				filter,
				Color.White,
				color,
				alpha);
		}

		/// <summary>
		/// Rellena el interior de un rectángulo con bordes con un fondo degradado con reflejo.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		/// <param name="color1">Color de inicio del degradado.</param>
		/// <param name="color2">Color de fin del degradado.</param>
		/// <param name="alpha">Especifíca el nivel de transparencia.</param>
		public static void FillCrystalRoundedRectangle(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RoundedEdgeFilters filter,
			Color color1,
			Color color2,
			int alpha)
		{
			HSLColor hslReflex1 = HSLColor.FromRGB(color1);
			hslReflex1.Luminance -= 0.05f;

			HSLColor hslReflex2 = HSLColor.FromRGB(color2);
			hslReflex2.Luminance -= 0.01f;

			graphics.FillCrystalRoundedRectangle(
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
		/// Rellena el interior de un rectángulo con bordes con un fondo degradado con reflejo.
		/// </summary>
		/// <param name="graphics"><see cref="Graphics"/> donde se dibujará el rectángulo.</param>
		/// <param name="rectangle"><see cref="Rectangle"/> que representa el rectángulo a dibujar.</param>
		/// <param name="radius">Radio que se aplicará a los bordes redondeados.</param>
		/// <param name="filter">Bordes a redondear.</param>
		/// <param name="color1">Color de inicio del degradado.</param>
		/// <param name="color2">Color de fin del degradado.</param>
		/// <param name="reflexColor1">Color de inicio para el efecto reflejo.</param>
		/// <param name="reflexColor2">Color de fin para el efecto reflejo.</param>
		/// <param name="alpha">Especifíca el nivel de transparencia.</param>
		public static void FillCrystalRoundedRectangle(
			this Graphics graphics,
			Rectangle rectangle,
			int radius,
			RoundedEdgeFilters filter,
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

		#region Helpers

		/// <summary>
		/// Devuelve el objeto GraphicsPath con la definición del rectángulo con las esquinas en forma de arco.
		/// </summary>
		private static GraphicsPath GenerateRoundedRectangle(
				this Graphics graphics,
				RectangleF rectangle,
				float radius,
				RoundedEdgeFilters filter)
		{
			if (radius <= 0.0F || filter == RoundedEdgeFilters.None)
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

				if ((RoundedEdgeFilters.TopLeft & filter) == RoundedEdgeFilters.TopLeft)
					path.AddArc(arc, 180, 90);
				else
				{
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
				}

				arc.X = rectangle.Right - diameter;

				if ((RoundedEdgeFilters.TopRight & filter) == RoundedEdgeFilters.TopRight)
					path.AddArc(arc, 270, 90);
				else
				{
					path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
					path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
				}

				arc.Y = rectangle.Bottom - diameter;

				if ((RoundedEdgeFilters.BottomRight & filter) == RoundedEdgeFilters.BottomRight)
					path.AddArc(arc, 0, 90);
				else
				{
					path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
					path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
				}

				arc.X = rectangle.Left;

				if ((RoundedEdgeFilters.BottomLeft & filter) == RoundedEdgeFilters.BottomLeft)
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
}
