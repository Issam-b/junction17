import bpy
import os
path = 'E:/models/stl_big'  # set this path
for root, dirs, files in os.walk(path):
    for f in files:
        if f.endswith('.stl') :
            mesh_file = os.path.join(path, f)
            obj_file = os.path.splitext(mesh_file)[0] + ".fbx"
            bpy.ops.object.select_all(action='SELECT')
            bpy.ops.object.delete()
            bpy.ops.import_mesh.ply(filepath=mesh_file) # change this line
            bpy.ops.object.select_all(action='SELECT')
            bpy.ops.export_scene.fbx(filepath=obj_file)