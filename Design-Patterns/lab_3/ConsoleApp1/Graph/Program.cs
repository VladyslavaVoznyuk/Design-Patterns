using Graph.Render;
using Graph.Shapes;


var circle = new Circle();
var rectangle = new Rectangle();
var triangle = new Triangle();


Shape bitmap = new Bitmap(circle);
bitmap.Render();

Shape bitmap2 = new Bitmap(rectangle);
bitmap2.Render();

Shape vector = new Vector(triangle);
vector.Render();

