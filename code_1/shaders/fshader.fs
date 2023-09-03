#version 330 core

in vec3 fColor;
in vec3 light_color_fs;
in vec3 light_pos_fs;
in vec3 cam_pos_fs;
in vec3 vVertex_fs;
in vec3 vertex_norm_fs;
in mat4 vModel_fs;
in vec3 vColor_fs;
out vec4 outColor;
void main(void) {


        vec3 light_pos_new = vec3(vModel_fs * vec4(light_pos_fs , 1.0));
        vec3 cam_pos_new = cam_pos_fs;


        float ka = 0.7;
        vec3 ambient_light = ka * light_color_fs;



        vec3 normal  = normalize(inverse(transpose(mat3(vModel_fs))) * vertex_norm_fs);
        vec3 frag_pos = vec3(vModel_fs * vec4(vVertex_fs , 1.0));
        vec3 light_dir = normalize(vec3(light_pos_new - frag_pos));
        float kd = 0.8;
        vec3 diffuse_light = kd * light_color_fs * max(0, dot(light_dir, normal));



        float ks = 0.9;
        vec3 view_dir = normalize(cam_pos_new  - frag_pos);
        vec3 h = normalize(light_dir + view_dir);
        vec3 specular_light = ks * light_color_fs * pow(max(0, dot(h ,normal)), 32);

        vec3 result = (ambient_light + diffuse_light + specular_light) * vColor_fs;
        outColor = vec4(result, 1.0);
}
