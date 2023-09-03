#version 330 core

in vec3 vVertex;
in vec3 vertex_norm;


uniform mat4 vModel;
uniform mat4 vView;
uniform mat4 vProjection;
uniform vec3 vColor;
uniform vec3 light_color;
uniform vec3 light_pos;
uniform vec3 cam_pos;

out vec3 fColor;
out vec3 light_color_fs;
out vec3 light_pos_fs;
out vec3 cam_pos_fs;
out vec3 vVertex_fs;
out vec3 vertex_norm_fs;
out mat4 vModel_fs;
out vec3 vColor_fs;



void main() {
	gl_Position = vProjection * vView * vModel * vec4(vVertex, 1.0);

	light_color_fs = light_color;
	light_pos_fs = light_pos;
	cam_pos_fs = cam_pos;
	vVertex_fs = vVertex;
	vertex_norm_fs = vertex_norm;
	vModel_fs = vModel;
	vColor_fs = vColor;

	fColor = vColor; //Interpolate color
}
